using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Mappers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Repositories;
using Labmark.Domain.Modules.Exam.Services.EscherichiaColiforms;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Services.EscherichiaColiforms
{
    public class CreateEscherichiaColiformsService : ICreateEscherichiaColiformsService
    {
        private readonly IColiformesEscherichiaRepository _coliformesEscherichiaRepository;
        private readonly IAmostraRepository _amostraRepository;
       

        public CreateEscherichiaColiformsService(IColiformesEscherichiaRepository coliformesEscherichiaRepository, IAmostraRepository amostraRepository)
        {
            _coliformesEscherichiaRepository = coliformesEscherichiaRepository;
            _amostraRepository = amostraRepository;
        }

        public async Task<ColiformsEscherichiaDto> Execute(ColiformsEscherichiaDto coliformsEscherichiaDto, int? sampleId)
        {
            if (sampleId <= 0)
            {
                throw new AppError("Informe uma diluição válida.");
            }
            Amostra amostra = await _amostraRepository.GetByID((int)sampleId);

            if (amostra == null)
            {
                throw new AppError("Informe uma diluição válida.");
            }

            ColiformesEscherichia coliformesEscherichia = ColiformsEscherichiaDtoMapToColiformesEscherichia.Map(new ColiformesEscherichia(), coliformsEscherichiaDto);
            coliformesEscherichia.fkEnsaiosPorAmostra = amostra.EnsaiosPorAmostras.Where(x => x.fkEnsaio.Id == coliformsEscherichiaDto.AssayId).First();
            coliformesEscherichia.fkEnsaiosPorAmostraId = amostra.EnsaiosPorAmostras.Where(x => x.fkEnsaio.Id == coliformsEscherichiaDto.AssayId).First().Id;

            _coliformesEscherichiaRepository.Insert(coliformesEscherichia);
            await _coliformesEscherichiaRepository.Commit();
            coliformsEscherichiaDto.Id = coliformesEscherichia.Id;
            return coliformsEscherichiaDto;
        }
    }
}

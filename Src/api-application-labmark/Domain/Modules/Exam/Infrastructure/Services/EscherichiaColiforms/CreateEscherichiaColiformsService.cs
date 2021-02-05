using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Mappers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Repositories;
using Labmark.Domain.Modules.Exam.Services.EscherichiaColiforms;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Services.EscherichiaColiforms
{
    public class CreateEscherichiaColiformsService : ICreateEscherichiaColiformsService
    {
        private readonly IColiformesEscherichiaRepository _coliformesEscherichiaRepository;

        public CreateEscherichiaColiformsService(IColiformesEscherichiaRepository coliformesEscherichiaRepository)
        {
            _coliformesEscherichiaRepository = coliformesEscherichiaRepository;
        }

        public async Task<ColiformsEscherichiaDto> Execute(ColiformsEscherichiaDto coliformsEscherichiaDto, int? dilutionSampleId)
        {
            if (dilutionSampleId <= 0)
            {
                throw new AppError("Informe uma diluição válida.");
            }
            ColiformesEscherichia coliformsEscherichia = await _coliformesEscherichiaRepository.GetByID((int)dilutionSampleId);
            if (coliformsEscherichiaDto == null)
            {
                throw new AppError("Informe uma diluição válida.");
            }
            ColiformesEscherichia coliformesEscherichia = ColiformsEscherichiaDtoMapToColiformesEscherichia.Map(new ColiformesEscherichia(), coliformsEscherichiaDto);
            _coliformesEscherichiaRepository.Insert(coliformesEscherichia);
            await _coliformesEscherichiaRepository.Commit();
            return coliformsEscherichiaDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.DilutionSample;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.DilutionSample
{
    public class CreateDilutionSampleService : ICreateDilutionSampleService
    {
        private readonly IDiluicaoAmostraRepository _DiluicaoAmostraRepository;
        private readonly IAmostraRepository _AmostraRepository;

        public CreateDilutionSampleService(IDiluicaoAmostraRepository DiluicaoAmostraRepository, IAmostraRepository AmostraRepository)
        {
            _DiluicaoAmostraRepository = DiluicaoAmostraRepository;
            _AmostraRepository = AmostraRepository;
        }

        public async Task<DilutionSampleDto> Execute(DilutionSampleDto dilutionSampleDto, int? sampleId)
        {
            if (sampleId <= 0)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            Amostra amostra = await _AmostraRepository.GetByID((int)sampleId);
            if (amostra == null)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            DiluicaoAmostra diluicaoAmostra = DilutionSampleDtoMapToDiluicaoAmostra.Map(new DiluicaoAmostra(), dilutionSampleDto);
            diluicaoAmostra.fkAmostra = amostra;
            diluicaoAmostra.fkAmostraId = amostra.Id;
            _DiluicaoAmostraRepository.Insert(diluicaoAmostra);
            await _DiluicaoAmostraRepository.Commit();
            return dilutionSampleDto;
        }
    }
}

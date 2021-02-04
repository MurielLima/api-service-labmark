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
    public class UpdateDilutionSampleService : IUpdateDilutionSampleService
    {
        private readonly IDiluicaoAmostraRepository _diluicaoAmostraRepository;

        public UpdateDilutionSampleService(IDiluicaoAmostraRepository diluicaoAmostraRepository)
        {
            _diluicaoAmostraRepository = diluicaoAmostraRepository;
        }

        public async Task<DilutionSampleDto> Execute(DilutionSampleDto dilutionSampleDto)
        {
            DiluicaoAmostra diluicaoAmostra = DilutionSampleDtoMapToDiluicaoAmostra.Map(new DiluicaoAmostra(), dilutionSampleDto);
            if (diluicaoAmostra == null)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            _diluicaoAmostraRepository.Save(diluicaoAmostra);
            await _diluicaoAmostraRepository.Commit();
            return dilutionSampleDto;
        }
    }
}

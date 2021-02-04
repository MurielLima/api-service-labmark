using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Sample;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Sample
{
    public class UpdateSampleService : IUpdateSampleService
    {
        private readonly IAmostraRepository _amostraRepository;

        public UpdateSampleService(IAmostraRepository amostraRepository)
        {
            _amostraRepository = amostraRepository;
        }

        public async Task<SampleDto> Execute(SampleDto sampleDto)
        {
            Amostra amostra = SampleDtoMapToAmostra.Map(new Amostra(), sampleDto);
            if(amostra == null)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            _amostraRepository.Save(amostra);
            await _amostraRepository.Commit();
            return sampleDto;
        }
    }
}

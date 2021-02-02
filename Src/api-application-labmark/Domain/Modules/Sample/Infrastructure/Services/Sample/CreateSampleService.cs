using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Sample;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Sample
{
    public class CreateSampleService : ICreateSampleService
    {
        private readonly IAmostraRepository _amostraRepository;
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public CreateSampleService(IAmostraRepository amostraRepository, ISolicitacaoRepository solicitacaoRepository)
        {
            _amostraRepository = amostraRepository;
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<SampleDto> Execute(SampleDto sampleDto, int? solicitationId)
        {
            if(solicitationId <= 0)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            Solicitacao solicitacao = await _solicitacaoRepository.GetByID((int)solicitationId);
            if(solicitacao == null)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            Amostra amostra = SampleDtoMapToAmostra.Map(new Amostra(), sampleDto);
            amostra.fkSolicitacao = solicitacao;
            amostra.fkSolicitacaoId = solicitacao.Id;
            _amostraRepository.Insert(amostra);
            await _amostraRepository.Commit();
            return sampleDto;
        }
    }
}

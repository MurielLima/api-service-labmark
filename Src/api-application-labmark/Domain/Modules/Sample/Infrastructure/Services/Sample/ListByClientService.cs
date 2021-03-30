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
    public class ListByClientService :IListByClientService
    {
        private readonly IAmostraRepository _amostraRepository;

        public ListByClientService(IAmostraRepository amostraRepository)
        {
            _amostraRepository = amostraRepository;
        }

        public async Task<IList<SampleDto>> Execute(int clientId)
        {
            IList<Amostra> amostras = new List<Amostra>();
            IList<SampleDto> sampleDtos = new List<SampleDto>();

            if (clientId > 0)
            {
                amostras = await _amostraRepository.Get(x => x.fkSolicitacao.fkPessoaId ==  clientId);
            }
            else
            {
                amostras = await _amostraRepository.Get();
            }
            if (amostras.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhuma amostra.", 404);
            }
            foreach (Amostra x in amostras)

                sampleDtos.Add(AmostraMapToSampleDto.Map(new SampleDto(), x));

            return sampleDtos;
        }
    }
}

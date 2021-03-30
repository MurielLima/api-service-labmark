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

namespace Labmark.Domain.Modules.DilutionSample.Infrastructure.Services.DilutionSample
{
    public class ListDilutionSampleService : IListDilutionSampleService
    {

        private readonly IDiluicaoAmostraRepository _diluicaoAmostraRepository;

        public ListDilutionSampleService(IDiluicaoAmostraRepository diluicaoAmostraRepository)
        {
            _diluicaoAmostraRepository = diluicaoAmostraRepository;
        }

        public async Task<IList<DilutionSampleDto>> Execute(int? sampleId)
        {
            IList<DiluicaoAmostra> diluicaoAmostras = new List<DiluicaoAmostra>();
            IList<DilutionSampleDto> sampleDtos = new List<DilutionSampleDto>();

            if (sampleId > 0)
            {
                DiluicaoAmostra diluicaoAmostra = await _diluicaoAmostraRepository.GetByID((int)sampleId);
                if (diluicaoAmostra != null)
                {
                    diluicaoAmostras.Add(diluicaoAmostra);
                }
            }
            else
            {
                diluicaoAmostras = await _diluicaoAmostraRepository.Get();
            }
            if (diluicaoAmostras.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhum cliente.", 404);
            }
            foreach (DiluicaoAmostra x in diluicaoAmostras)
                sampleDtos.Add(DiluicaoAmostraMapToDilutionSampleDto.Map(new DilutionSampleDto(), x));

            return (IList<DilutionSampleDto>)sampleDtos.OrderBy(s=>s.Id);
        }
    }
}

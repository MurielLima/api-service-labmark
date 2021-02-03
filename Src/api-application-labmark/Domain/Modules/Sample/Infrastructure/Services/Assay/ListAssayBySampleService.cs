using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Assay;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Assay
{
    public class ListAssayBySampleDilutionService : IListAssaySampleDilutionService
    {
        private readonly IDiluicaoAmostraRepository _diluicaoAmostraRepository;

        public ListAssayBySampleDilutionService(IDiluicaoAmostraRepository diluicaoAmostraRepository)
        {
            _diluicaoAmostraRepository = diluicaoAmostraRepository;
        }

        public async Task<IList<AssayDto>> Execute(int sampleDilutionId)
        {
            IList<AssayDto> assayDtos = new List<AssayDto>();
            DiluicaoAmostra diluicaoAmostra = new DiluicaoAmostra();
            diluicaoAmostra = await _diluicaoAmostraRepository.GetByID((int)sampleDilutionId);
            foreach (IList<EnsaiosPorAmostra> x in diluicaoAmostra.fkAmostra.fkEnsaiosPorAmostras)
                foreach(var y in x)
                    assayDtos.Add(EnsaioMapToAssayDto.Map(new AssayDto(), y.fkEnsaio));

            return assayDtos;
        }
    }
}
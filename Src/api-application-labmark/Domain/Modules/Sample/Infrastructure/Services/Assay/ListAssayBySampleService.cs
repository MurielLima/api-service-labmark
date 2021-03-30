using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Assay;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

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
            if (diluicaoAmostra == null)
            {
                throw new AppError("Não foi encontrada nenhuma Diluição para essa amostra.", 404);
            }

            foreach (EnsaiosPorAmostra x in diluicaoAmostra.fkAmostra.EnsaiosPorAmostras)
            {
                AssayDto assay = EnsaioMapToAssayDto.Map(new AssayDto(), x.fkEnsaio);
                assay.sample = AmostraMapToSampleDto.Map(new SampleDto(), diluicaoAmostra.fkAmostra);
                assayDtos.Add(assay);
            }
            return assayDtos.OrderBy(assay => assay.Description).ToList();
        }
    }
}
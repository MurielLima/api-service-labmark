using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Experiment;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Experiment.Infrastructure.Services.Experiment
{
    public class ListExperimentService : IListExperimentService
    {
        private readonly IExperimentoRepository _experimentoRepository;
        private readonly IDiluicaoAmostraRepository _diluicaoAmostraRepository;

        public ListExperimentService(IExperimentoRepository experimentoRepository, IDiluicaoAmostraRepository diluicaoAmostraRepository)
        {
            _experimentoRepository = experimentoRepository;
            _diluicaoAmostraRepository = diluicaoAmostraRepository;
        }

        public async Task<IList<ExperimentDto>> Execute(int? experimentId, int? sampleDilutionId = 0)
        {
            IList<Experimento> experiments = new List<Experimento>();
            IList<ExperimentDto> experimentDtos = new List<ExperimentDto>();
            DiluicaoAmostra diluicaoAmostra = new DiluicaoAmostra();
            if (sampleDilutionId > 0)
            {
                diluicaoAmostra = await _diluicaoAmostraRepository.GetByID((int)sampleDilutionId);
                foreach (Experimento x in experiments)
                    experimentDtos.Add(ExperimentoMapToExperimentDto.Map(new ExperimentDto(), x));
            }

            if (experimentId > 0)
            {
                Experimento experiment = await _experimentoRepository.GetByID((int)experimentId);
                if (experiment != null)
                {
                    experiments.Add(experiment);
                }
            }
            else
            {
                experiments = await _experimentoRepository.Get();
            }
            if (experiments.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhum experimento.", 404);
            }
            foreach (Experimento x in experiments)
                experimentDtos.Add(ExperimentoMapToExperimentDto.Map(new ExperimentDto(), x));
            return experimentDtos;
        }
    }
}

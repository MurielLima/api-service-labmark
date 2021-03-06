﻿using System;
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

        public async Task<IList<ExperimentDto>> Execute(int? experimentId, int? sampleDilutionId)
        {
            IList<Experimento> experiments = new List<Experimento>();
            IList<ExperimentDto> experimentDtos = new List<ExperimentDto>();
            DiluicaoAmostra diluicaoAmostra = new DiluicaoAmostra();
            if (sampleDilutionId > 0)
            {
                diluicaoAmostra = await _diluicaoAmostraRepository.GetByID((int)sampleDilutionId);
                experiments = await _experimentoRepository.Get(x=> x.fkDiluicaoAmostraId == diluicaoAmostra.Id);
                foreach (Experimento x in experiments)
                    experimentDtos.Add(ExperimentoMapToExperimentDto.Map(new ExperimentDto(), x));

                return experimentDtos;
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
            foreach (Experimento x in experiments)
                experimentDtos.Add(ExperimentoMapToExperimentDto.Map(new ExperimentDto(), x));
            return experimentDtos.OrderBy(e=>e.Id).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Experiment;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Experiment
{
    public class UpdateExperimentService : IUpdateExperimentService
    {
        private readonly IExperimentoRepository _experimentRepository;

        public UpdateExperimentService(IExperimentoRepository experimentRepository)
        {
            _experimentRepository = experimentRepository;
        }

        public async Task<ExperimentDto> Execute(ExperimentDto dilutionSampleDto)
        {
            Experimento experiment = ExperimentDtoMapToExperimento.Map(new Experimento(), dilutionSampleDto);
            if (experiment == null)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            _experimentRepository.Save(experiment);
            await _experimentRepository.Commit();
            return dilutionSampleDto;
        }
    }
}

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
    public class CreateExperimentService : ICreateExperimentService
    {
        private readonly IExperimentoRepository _experimentoRepository;

        public CreateExperimentService(IExperimentoRepository experimentoRepository)
        {
<<<<<<< Updated upstream
            _experimentoRepository = experimentoRepository;
=======
            _experimentRepository = experimentoRepository;
>>>>>>> Stashed changes
        }

        public async Task<ExperimentDto> Execute(ExperimentDto experimentDto, int? dilutionSampleId)
        {
            if (dilutionSampleId <= 0)
            {
                throw new AppError("Informe uma diluição válida.");
            }
            Experimento experiment = await _experimentoRepository.GetByID((int)dilutionSampleId);
            if (experimentDto == null)
            {
                throw new AppError("Informe uma diluição válida.");
            }
<<<<<<< Updated upstream
            Experimento experimento = ExperimentDtoMapToExperimento.Map(new Experimento(), experimentDto);
=======
            Experimento experimento = ExperimentDtoMapToExperiment.Map(new Experimento(), experimentDto);
>>>>>>> Stashed changes
            _experimentoRepository.Insert(experimento);
            await _experimentoRepository.Commit();
            return experimentDto;
        }
    }
}

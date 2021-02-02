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
        private readonly IDiluicaoAmostraRepository _dilutionSampleRepository;

        public CreateExperimentService(IExperimentoRepository experimentoRepository, IDiluicaoAmostraRepository dilutionSampleRepository)
        {

            _experimentoRepository = experimentoRepository;
            _dilutionSampleRepository = dilutionSampleRepository;
        }

        public async Task<ExperimentDto> Execute(ExperimentDto experimentDto, int? dilutionSampleId)
        {
            if (dilutionSampleId <= 0)
            {
                throw new AppError("Informe uma diluição válida.");
            }
            DiluicaoAmostra dilutionSample = await _dilutionSampleRepository.GetByID((int)dilutionSampleId);
            if (dilutionSample == null)
            {
                throw new AppError("Informe uma diluição válida.");
            }

            Experimento experimento = ExperimentDtoMapToExperimento.Map(new Experimento(), experimentDto);
            experimento.fkDiluicaoAmostra = dilutionSample;
            experimento.fkDiluicaoAmostraId = dilutionSample.Id;

            _experimentoRepository.Insert(experimento);
            await _experimentoRepository.Commit();
            return experimentDto;
        }
    }
}

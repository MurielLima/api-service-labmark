﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Mappers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Repositories;
using Labmark.Domain.Modules.Exam.Services.EscherichiaColiforms;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Services.EscherichiaColiforms
{
    public class UpdateEscherichiaColiformsService : IUpdateEscherichiaColiformsService
    {

        private readonly IColiformesEscherichiaRepository _coliformesEscherichiaRepository;

        public UpdateEscherichiaColiformsService(IColiformesEscherichiaRepository coliformesEscherichiaRepository)
        {
            _coliformesEscherichiaRepository = coliformesEscherichiaRepository;
        }

        public async Task<ColiformsEscherichiaDto> Execute(ColiformsEscherichiaDto coliformsEscherichiaDto)
        {

            ColiformesEscherichia coliformesEscherichia = await _coliformesEscherichiaRepository.GetByID(coliformsEscherichiaDto.Id);

            if (coliformsEscherichiaDto.FlowMicropipettor != null && coliformsEscherichiaDto.FlowMicropipettor != null && coliformsEscherichiaDto.FlowMicropipettor != null)
                           
            {
                coliformesEscherichia.Fluxo_Micropipetador = coliformsEscherichiaDto.FlowMicropipettor;
                coliformesEscherichia.Ponteira_Alcada = coliformsEscherichiaDto.Pointer_Reach;
                coliformesEscherichia.Pipeta = coliformsEscherichiaDto.Point;
            }
            else
            {
                coliformesEscherichia.LeituraTotais = coliformsEscherichiaDto.ReadingTotal;
                coliformesEscherichia.ResultadoColiformesTotais = coliformsEscherichiaDto.ResultTotalColiforms;
                coliformesEscherichia.LeituraTermotolerantes = coliformsEscherichiaDto.ReadingThermotolerant;
                coliformesEscherichia.ResultadoColiformesTermotolerantes = coliformsEscherichiaDto.ResultThermotolerantColiforms;
            }



            _coliformesEscherichiaRepository.Save(coliformesEscherichia);
            await _coliformesEscherichiaRepository.Commit();
            coliformsEscherichiaDto.Id = coliformesEscherichia.Id;
            return coliformsEscherichiaDto;
        }








    }
}

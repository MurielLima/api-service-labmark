using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class ColiformesEscherichiaMapToColiformsEscherichiaDto
    {

        public static ColiformsEscherichiaDto Map(ColiformsEscherichiaDto coliformsEscherichiaDto, ColiformesEscherichia coliformesEscherichia)
        {
            coliformsEscherichiaDto.BOD = coliformesEscherichia.BOD ?? 0;
            coliformsEscherichiaDto.Brilla = coliformesEscherichia.Brilla;
            coliformsEscherichiaDto.DateOfCompletion = coliformesEscherichia.DataResultado;
            coliformsEscherichiaDto.DateResult = coliformesEscherichia.DataResultado;
            coliformsEscherichiaDto.Escherichia = coliformesEscherichia.Escherichia;
            




            return null;
        }








    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Services.EscherichiaColiforms
{
    public interface ICreateEscherichiaColiformsService
    {
        Task<ColiformsEscherichiaDto> Execute(ColiformsEscherichiaDto coliformsEscherichiaDto);
    }
}

﻿using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Controllers
{
    public interface IEscherichiaColiformsController
    {
        public Task<IActionResult> Create([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto, int? sampleId);
        public Task<IActionResult> Update([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto);
    }
}

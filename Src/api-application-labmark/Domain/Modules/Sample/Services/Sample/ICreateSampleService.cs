﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Sample.Services.Sample
{
    public interface ICreateSampleService
    {
        Task<SampleDto> Execute(SampleDto sampleDto, int? solicitationId);
    }
}

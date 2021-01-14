﻿using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class WaterDilutionDto
    {
        public int Id { get; set; }
        public DilutionSampleDto DilutionSample { get; set; }
        public EnumWaterDilution Code { get; set; }
        public double Value { get; set; }
    }
}
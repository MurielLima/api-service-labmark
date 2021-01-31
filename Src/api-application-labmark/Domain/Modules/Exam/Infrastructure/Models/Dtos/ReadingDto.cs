﻿using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class ReadingDto
    {
        public int Id { get; set; }

        public double Reading { get; set; }

        public virtual ICollection<Diluicao> Dilutions { get; set; }


    }
}
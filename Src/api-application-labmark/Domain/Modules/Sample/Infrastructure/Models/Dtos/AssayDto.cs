using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class AssayDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Methodology { get; set; }
        public string Reference { get; set; }
    }
}

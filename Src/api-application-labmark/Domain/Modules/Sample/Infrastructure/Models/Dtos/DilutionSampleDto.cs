using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class DilutionSampleDto
    {
        public EnumLocal Local { get; set; }
        public int Homogenizer { get; set; }
        public int Micropipette { get; set; }
        public int Pipette { get; set; }
        public int Shaker { get; set; }
        public int Board { get; set; }
        public int Others { get; set; }
        public int Id { get; set; }
        public SampleDto Sample { get; set; }
        public IList<PointDto> Points { get; set; }
        public IList<WaterDilutionDto> WaterDilutions { get; set; }
    }
}

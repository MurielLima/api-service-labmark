using System.Collections.Generic;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class DilutionSampleDto
    {
        public LocationDto Location { get; set; }
        public int? Homogenizer { get; set; }
        public int? Micropipette { get; set; }
        public int? Pipette { get; set; }
        public int? Shaker { get; set; }
        public double? Board { get; set; }
        public string Others { get; set; }
        public int Id { get; set; }
        public SampleDto Sample { get; set; }
        public IList<PointDto> Points { get; set; }
        public IList<WaterDilutionDto> WaterDilutions { get; set; }
    }
}

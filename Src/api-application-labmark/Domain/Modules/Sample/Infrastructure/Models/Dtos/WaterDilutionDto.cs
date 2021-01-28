using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class WaterDilutionDto
    {
        public WaterDilutionDto(EnumWaterDilution enumWaterDilution)
        {
            Code = enumWaterDilution;
        }


        public int Id { get; set; }
        public DilutionSampleDto DilutionSample { get; set; }
        public EnumWaterDilution Code { get; set; }
        public double Value { get; set; }
    }
}

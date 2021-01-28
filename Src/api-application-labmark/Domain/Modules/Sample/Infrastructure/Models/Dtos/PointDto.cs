using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class PointDto
    {
        public PointDto()
        {

        }
        public PointDto(EnumPoints enumPoints)
        {
            Code = enumPoints;
        }

        public int Id { get; set; }
        public DilutionSampleDto DilutionSample { get; set; }
        public double Middle { get; set; }
        public int BOD { get; set; }
        public string Lot { get; set; }

        public EnumPoints Code { get; set; }
    }
}

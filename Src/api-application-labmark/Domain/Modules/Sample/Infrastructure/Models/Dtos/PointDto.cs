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
        public int Value { get; set; }

        public EnumPoints Code { get; set; }
    }
}

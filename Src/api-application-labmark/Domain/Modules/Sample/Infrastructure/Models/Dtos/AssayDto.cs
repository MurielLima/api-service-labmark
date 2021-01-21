using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class AssayDto
    {
        public AssayDto()
        {

        }
        public AssayDto(EnumAssay enumAssay)
        {
            Code = enumAssay;
        }
        public int Id { get; set; }
        public EnumAssay Code { get; set; }
        public bool Value { get; set; }
        public string Methodology { get; set; }
        public string Reference { get; set; }

    }
}

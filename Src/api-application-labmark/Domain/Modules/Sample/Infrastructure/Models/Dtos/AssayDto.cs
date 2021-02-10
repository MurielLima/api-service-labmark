using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class AssayDto
    {
        public AssayDto()
        {
            sample = new SampleDto();
        }
        public AssayDto(EnumAssay enumAssay, int id)
        {
            Code = enumAssay;
            Id = id;
            sample = new SampleDto();
        }
        public int Id { get; set; }
        public SampleDto sample { get; set; }
        public EnumAssay Code { get; set; }
        public bool Value { get; set; }
        public string Methodology { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

     

    }
}

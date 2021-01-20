namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class PointDto
    {
        public int Id { get; set; }
        public DilutionSampleDto DilutionSample { get; set; }
        public double Middle { get; set; }
        public int BOD { get; set; }
        public string Lot { get; set; }
    }
}

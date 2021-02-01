namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class ExperimentDto
    {
        public int Id { get; set; }
        public DilutionSampleDto DilutionSample { get; set; }
        public string Middle { get; set; }
        public int? BOD { get; set; }
        public string Lot { get; set; }
    }
}

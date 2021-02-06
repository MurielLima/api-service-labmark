namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class ExperimentDto
    {
        public ExperimentDto()
        {
            DilutionSample = new DilutionSampleDto();
        }
        public int Id { get; set; }
        public DilutionSampleDto DilutionSample { get; set; }
        public string Dilution { get; set; }
        public string Middle { get; set; }
        public int? BOD { get; set; }
        public string Lot { get; set; }
    }
}

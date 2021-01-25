using System;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos
{
    public class IncubationDto
    {
        public int Id { get; set; }
        public DateTime CompleteDate { get; set; }
        public int IncubationTemperature { get; set; }
        public string Task { get; set; }
        public string Process { get; set; }
    }
}

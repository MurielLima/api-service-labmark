using System;
using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class SampleDto
    {
        public string Description { get; set; }
        public int Lot { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime FabricationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Id { get; set; }
        public ClientDto Client { get; set; }
        public SolicitationDto Solicitation { get; set; }
        public IList<AssayDto> Assays { get; set; }
    }
}

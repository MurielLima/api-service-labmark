using System;
using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos
{
    public class SolicitationDto
    {
        public int Id { get; set; }
        public ClientDto clientDto { get; set; }
        public string Observation { get; set; }
        public DateTime CompletionDate { get; set; }
        public IList<AskDto> AskDtos { get; set; }
    }
}

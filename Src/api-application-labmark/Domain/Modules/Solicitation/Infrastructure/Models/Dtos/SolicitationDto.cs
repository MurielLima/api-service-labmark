using System;
using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos
{
    public class SolicitationDto
    {
        public SolicitationDto()
        {
            clientDto = new ClientDto();
            AskDtos = new List<AskDto>();
        }
        public int Id { get; set; }
        public ClientDto clientDto { get; set; }
        public string Observation { get; set; }
        public DateTime CompletionDate { get; set; }
        public DateTime ReceivingDate { get; set; } = DateTime.Now;
        public IList<AskDto> AskDtos { get; set; }


    }
}

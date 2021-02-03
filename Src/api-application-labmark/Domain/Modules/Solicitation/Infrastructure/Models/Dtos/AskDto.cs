using System.ComponentModel.DataAnnotations;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos
{
    public class AskDto
    {
        public AskDto()
        {
        }
        public AskDto(EnumQuestion enumQuestion)
        {
            Code = enumQuestion;
        }
        public int Id { get; set; }
        public EnumQuestion Code { get; set; }
        [MaxLength(1)]
        [Required]
        [RegularExpression("(([S])|([N]))", ErrorMessage = "Campo Resposta deve ser preenchido com 'S' ou 'N'")]
        public string Answer { get; set; }
    }
}
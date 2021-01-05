using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class PhoneDto
    {
        public PhoneDto(string ddd, string number)
        {
            Ddd = ddd;
            Number = number;
        }

        public int Id { get; set; }
        [MaxLength(3)]
        public string Ddd { get; set; }
        [MaxLength(11)]
        public string Number { get; set; }
    }
}

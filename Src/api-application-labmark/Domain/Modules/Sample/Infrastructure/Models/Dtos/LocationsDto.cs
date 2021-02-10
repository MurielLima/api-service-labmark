using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class LocationDto
    {
        public LocationDto()
        {
        }

        public LocationDto(EnumLocal enumLocal)
        {
            Code = enumLocal;
            Id = (int)enumLocal;
        }

        public int Id { get; set; }
        public EnumLocal Code { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Services
{
    public interface IListSolicitationService
    {
        Task<IList<SolicitationDto>> Execute(int? solicitationId);
    }
}

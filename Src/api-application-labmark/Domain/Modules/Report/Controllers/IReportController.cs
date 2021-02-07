using System.Threading.Tasks;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.ReportSample.Controllers
{
    public interface IReportController
    {
        public IActionResult Generate([FromBody] ReportDto query);
    }
}

using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Controllers
{
    public interface ICountMBLBController
    {
        public Task<IActionResult> Create([FromBody] CountMBLBDto countMBLB, int? sampleId);
        public Task<IActionResult> Update(int? id);
    }
}

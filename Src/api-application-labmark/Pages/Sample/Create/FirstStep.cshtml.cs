using System.Collections.Generic;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class FirstStepModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            _solicitationDto.AskDtos = new List<AskDto>();
            _packaged.Code = EnumQuestion.Packaged;
            _proccess.Code = EnumQuestion.Proccess;
            _temperature.Code = EnumQuestion.Temperature;
            _transport.Code = EnumQuestion.Transport;
            _volume.Code = EnumQuestion.Volume;
            _solicitationDto.AskDtos.Add(_packaged);
            _solicitationDto.AskDtos.Add(_proccess);
            _solicitationDto.AskDtos.Add(_volume);
            _solicitationDto.AskDtos.Add(_temperature);
            _solicitationDto.AskDtos.Add(_transport);
            return Page();
        }
        [BindProperty]
        public SolicitationDto _solicitationDto { get; set; }
        [BindProperty]
        public AskDto _packaged { get; set; }
        [BindProperty]
        public AskDto _proccess { get; set; }
        [BindProperty]
        public AskDto _temperature { get; set; }
        [BindProperty]
        public AskDto _transport { get; set; }
        [BindProperty]
        public AskDto _volume { get; set; }
    }
}

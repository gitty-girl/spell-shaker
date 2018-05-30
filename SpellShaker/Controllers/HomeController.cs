using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpellChecker.Models.SpellCheck;
using SpellChecker.Services;

namespace SpellChecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpellCheckService _service;

        public HomeController(ISpellCheckService service)
        {
            _service = service;
        }

        public IActionResult Index() =>
            View(new SpellCheckDto());

        [HttpPost]
        public async Task<IActionResult>  SpellCheck([FromForm]SpellCheckDto dto) =>
            View("Index", await _service.SpellCheck(dto.Input));
    }
}

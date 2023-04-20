using BugTracker_Backend.Data;
using BugTracker_Backend.Services;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketTypesController : Controller
    {
        private readonly IBTDropDownOptionsService _dropDownOptionsService;

        public TicketTypesController(IBTDropDownOptionsService dropDownOptionsService)
        {
            _dropDownOptionsService = dropDownOptionsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        // GET: Options
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Options()
        {
            var dropDownInfo = _dropDownOptionsService.GetAllTicketTypesAsync();

            return Ok(dropDownInfo);
        }
    }
}

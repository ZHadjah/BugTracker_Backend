using BugTracker_Backend.Data;
using BugTracker_Backend.Models;
using BugTracker_Backend.Models.Enums;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IBTDashboardInfoService _dashboardService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
                              IBTDashboardInfoService dashboardService)
        {
            _logger = logger;
            _context = context;
            _dashboardService = dashboardService;
        }

        [Route("")]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string dashboardInfo = await _dashboardService.GetDashboardNumbers(); 

            return Ok(dashboardInfo);
        }     

        //[HttpGet]
        //[Route("[action]")]
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //[Route("[action]")]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
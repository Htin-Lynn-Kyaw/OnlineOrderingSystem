using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineOrderingSystem.Models;
using OnlineOrderingSystem.Models.Entities;
using OnlineOrderingSystem.Utilities;
using System.Diagnostics;

namespace OnlineOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.UserRole = "Client";
            return View();
        }

        public IActionResult Privacy()
        {
            //bool IsOk = User.IsInRole(SystemsRoles.ADMIN);

            //var user = await _userManager.GetUserAsync(HttpContext.User);

            //await _userManager.AddToRoleAsync(user, SystemsRoles.ADMIN);
            //if (user == null)
            //{
            //    return NotFound(); // Handle user not found
            //}

            //// Get the list of roles for the user
            //var roles = await _userManager.GetRolesAsync(user);
            //Console.WriteLine(roles);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

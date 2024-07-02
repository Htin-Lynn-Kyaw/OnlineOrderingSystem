using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineOrderingSystem.Utilities;

namespace OnlineOrderingSystem.Controllers
{
    [Authorize(Roles = SystemsRoles.ADMIN)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Admin";
            return View();
        }
    }
}

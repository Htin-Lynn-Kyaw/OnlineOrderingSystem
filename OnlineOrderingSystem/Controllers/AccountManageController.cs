using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineOrderingSystem.Controllers
{
    public class AccountManageController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("manage-profile")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}

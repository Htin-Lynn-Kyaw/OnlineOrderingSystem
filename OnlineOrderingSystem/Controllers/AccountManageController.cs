using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineOrderingSystem.Database;
using OnlineOrderingSystem.Models.Entities;
using OnlineOrderingSystem.Models.ViewModels;
using System.IO;

namespace OnlineOrderingSystem.Controllers
{
    [Authorize]
    public class AccountManageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AccountManageController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("manage-profile")]
        public async Task<IActionResult> ProfileAsync()
        {
            AppUser? user = await _userManager.GetUserAsync(HttpContext.User);
            VMProfile profile = new VMProfile();
            if (user!.AddressID is not null)
            {
                Address address = (await _context.Addresses.FindAsync(user.AddressID))!;
                profile.Street = address.Street;
                profile.City = address.City;
                profile.Township = address.Township;
                profile.Details = address.Details;
                profile.Nickname = user.Nickname;
            }
            return View(profile);
        }

        [HttpPost]
        [Route("add-profile")]
        public async Task<IActionResult> AddProfileAsync(VMProfile model)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.GetUserAsync(HttpContext.User);

                if (user is null) return Unauthorized();

                Address address = new Address();
                if (user.AddressID is null)
                {
                    address = new Address();
                    address.AddressID = Guid.NewGuid(); 
                }
                else
                {
                    address = (await _context.Addresses.FirstOrDefaultAsync(a => a.AddressID == user.AddressID))!;
                }
                address.City = model.City;
                address.Township = model.Township;
                address.Street = model.Street;
                address.Details = model.Details;
                address.AppUser = user;

                if (user.AddressID is null)
                {
                    address.AddressID = Guid.NewGuid();
                    await _context.Addresses.AddAsync(address);
                }
                else
                {
                    address.AddressID = user.AddressID.Value;
                }
                //await _context.SaveChangesAsync();

                user.AddressID = address.AddressID;
                user.Address = address;
                user.Nickname = model.Nickname;

                //_context.Users.Update(user);
                await _context.SaveChangesAsync();

                ViewBag.SuccessMessage = user.AddressID is null? "Saving successful!" : "Updating successful";
            }
            return View("Profile", model);
        }
    }
}

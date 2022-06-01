using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Decanatus.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Decanatus.Web.Controllers
{
    [Authorize(Roles = "Адміністратор, Студент, Викладач")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IHomeService homeService, UserManager<ApplicationUser> userManager)
        {
            _homeService = homeService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_userManager.GetRolesAsync(_userManager.Users.FirstOrDefault(user => user.Id == _userManager.GetUserId(User))).Result.Contains("Студент"))
            {
                return View(_homeService.GetStudent(_userManager.GetUserAsync(User).Result.PersonId));
            }

            return View(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
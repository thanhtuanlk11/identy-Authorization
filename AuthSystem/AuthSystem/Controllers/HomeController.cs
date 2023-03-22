using AuthSystem.Areas.Identity.Data;
using AuthSystem.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userName = _userManager.GetUserName(User);
            var user = await _userManager.FindByNameAsync(userName);
            HomeDTO home = new HomeDTO();
            

            home.UserName = user.UserName;
            home.FirtName = user.FirtsName;
            home.LastName = user.LastName;
            home.SDT = user.PhoneNumber;
            home.Address = user.Address;
            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}


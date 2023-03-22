using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Areas.Identity.Pages.User
{
    public class UserModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        public UserModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public List<AppUser> users { get; set; }
        [TempData] 
        public string StatusMessage { get; set; }

        public async Task OnGet()
        {
            users = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();
        }
    }
}

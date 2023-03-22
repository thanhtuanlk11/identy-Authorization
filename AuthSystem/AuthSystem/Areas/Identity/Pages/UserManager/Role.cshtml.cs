using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthSystem.Areas.Identity.Pages.Role
{
    public class RoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public List<IdentityRole> roles { set; get; }

        [TempData] // Sử dụng Session lưu thông báo
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            roles = await _roleManager.Roles.ToListAsync();
            return Page();
        }
    }
}

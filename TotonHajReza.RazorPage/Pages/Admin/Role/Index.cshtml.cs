using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Models.Role;
using TotonHajReza.RazorPage.Services.Roles;

namespace TotonHajReza.RazorPage.Pages.Admin.Role
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
      
        public List<RoleDto> Roles { get; set; }

        public async Task OnGet()
        {
            Roles = await _roleService.GetRoleList();
            
        }
    }
}

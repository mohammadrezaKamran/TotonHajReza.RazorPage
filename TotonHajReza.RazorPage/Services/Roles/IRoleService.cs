using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Role;

namespace TotonHajReza.RazorPage.Services.Roles
{
    public interface IRoleService
    {
        Task<ApiResult> CreateRole(CreateRoleCommand commmand);
        Task<ApiResult> EditRole(EditRoleCommand commmand);

        Task<RoleDto> GetRoleById(long RoleId);
        Task<List<RoleDto>> GetRoleList();
    }
}

using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Role;

namespace TotonHajReza.RazorPage.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _client;
        private const string ModuleName= "Role";
        public RoleService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> CreateRole(CreateRoleCommand commmand)
        {
            var result=await _client.PostAsJsonAsync(ModuleName, commmand);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditRole(EditRoleCommand commmand)
        {
            var result = await _client.PutAsJsonAsync(ModuleName, commmand);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<RoleDto> GetRoleById(long RoleId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<RoleDto>>($"{ModuleName}/{RoleId}");
            return result.Data;

        }

        public async Task<List<RoleDto>> GetRoleList()
        {
            var result= await _client.GetFromJsonAsync<ApiResult<List<RoleDto>>>(ModuleName);
            return result.Data;
        }
    }
}

using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Auth;

namespace TotonHajReza.RazorPage.Services.Auth
{
    public interface IAuthService
    {
        Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
        Task<ApiResult?> Register(RegisterCommand command);
        Task<ApiResult?> Logout();
    }
}

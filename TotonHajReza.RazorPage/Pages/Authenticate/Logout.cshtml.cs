using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Services.Auth;

namespace TotonHajReza.RazorPage.Pages.Authenticate
{
    public class LogoutModel : BaseRazorPage
    {
		private readonly IAuthService _authService;

		public LogoutModel(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<IActionResult> OnGet()
		{
			var result = await _authService.Logout();

			if (result.IsSuccess)
			{
				HttpContext.Response.Cookies.Delete("token");
				HttpContext.Response.Cookies.Delete("refresh-token");
			}
			return RedirectAndShowAlert(result, RedirectToPage("../Index"));
		}
	}
}

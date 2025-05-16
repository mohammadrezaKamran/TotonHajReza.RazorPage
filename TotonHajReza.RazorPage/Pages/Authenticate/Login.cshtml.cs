using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Auth;
using TotonHajReza.RazorPage.Services.Auth;

namespace TotonHajReza.RazorPage.Pages.Authenticate
{
    [BindProperties]
	[ValidateAntiForgeryToken]
    public class LoginModel : BaseRazorPage
    {
		private readonly IAuthService _authService;

		public LoginModel(IAuthService authService)
		{
			_authService = authService;
		}
		#region
		[Display(Name = "شماره موبایل")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression("^([0-9]{11})$", ErrorMessage = "شماره موبایل معتبر نیست")]
		public string PhoneNumber { get; set; }

		[Display(Name = "کلمه عبور")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		[MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر ار 5 کاراکتر باشد")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		#endregion
		public IActionResult OnGet()
        {
			if (User.Identity.IsAuthenticated)
				return Redirect("/");
			return Page();
        }
		public async Task<IActionResult> OnPost()
		{
			var result =await _authService.Login(new LoginCommand()
			{
				PhoneNumber = PhoneNumber,
				Password = Password
			});
			if (result.IsSuccess == false)
			{
				ModelState.AddModelError(nameof(PhoneNumber), result.MetaData.Message);
				return Page();
			}
			var token=result.Data.Token;
			var refreshToken=result.Data.RefreshToken;

            HttpContext.Response.Cookies.Append("token", token, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(7)
            });
            HttpContext.Response.Cookies.Append("refresh-token", refreshToken, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.Now.AddDays(10)
            });

            return Redirect("/");
		}
    }
}

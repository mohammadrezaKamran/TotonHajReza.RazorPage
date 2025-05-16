using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Users.Commands;
using TotonHajReza.RazorPage.Services.Users;

namespace TotonHajReza.RazorPage.Pages.Profile
{
    [BindProperties]
    public class ChangePasswordModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public ChangePasswordModel(IUserService userService)
        {
            _userService = userService;
        }
        #region Properties
        [Display(Name = "کلمه عبور جاری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر ار 5 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بزرگتر ار 5 کاراکتر باشد")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه عبور جدید")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare("NewPassword", ErrorMessage = "کلمه های عبورر یکسان نیستند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        #endregion

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _userService.ChangePassword(new ChangePasswordCommand()
            {
                CurrentPassword = CurrentPassword,
                Password = NewPassword,
                ConfirmPassword = ConfirmPassword
            });

            return RedirectAndShowAlert(result,RedirectToPage("index")); 
        }
    }
}

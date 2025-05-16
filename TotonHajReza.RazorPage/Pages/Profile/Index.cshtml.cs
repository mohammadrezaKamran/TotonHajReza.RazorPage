using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using TotonHajReza.RazorPage.Models.Users;
using TotonHajReza.RazorPage.Models.Users.Commands;
using TotonHajReza.RazorPage.Services.Users;

namespace TotonHajReza.RazorPage.Pages.Profile
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        #region ProPerties

        [Display(Name = "عکس پروفایل")]
        [FileImage(ErrorMessage = "تصویر پروفایل نامعتبر است")]
        public IFormFile? Avatar { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Family { get; set; }

      
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^([0-9]{11})$", ErrorMessage = "شماره موبایل معتبر نیست")]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }

        public Gender Gender { get; set; } = Gender.None;

        #endregion

        public async Task OnGet()
        {
            var user = await _userService.GetCurrentUser();

            if (user != null)
            {
                Name = user.Name;
                Family = user.Family;
                PhoneNumber = user.PhoneNumber;
                Email = user.Email;
                Gender = user.Gender;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var result=await _userService.EditCurrentUser(new EditUserCommand(){
                Name = Name,
                Family = Family,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Gender = Gender,
                Avatar = Avatar,
            });
            return RedirectAndShowAlert(result, RedirectToPage());
        }

   
    }
}

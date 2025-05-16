using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Banners;
using TotonHajReza.RazorPage.Services.Banners;

namespace TotonHajReza.RazorPage.Pages.Admin.Banner
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {
        private readonly IBannerService _bannerService;

        public AddModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Url)]
        public string Link { get; set; }
        public BannerPosition Position { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        //[FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile ImageFile { get; set; }
      
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _bannerService.CreateBanner(new CreateBannerCommand()
            {
                Link = Link,
                Position = Position,
                ImageFile = ImageFile
            });

            return RedirectAndShowAlert(result, RedirectToPage("index"));
        }
    }
}

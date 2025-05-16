using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Banners;
using TotonHajReza.RazorPage.Services.Banners;

namespace TotonHajReza.RazorPage.Pages.Admin.Banner
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly IBannerService _bannerService;

        public EditModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Url)]
        public string Link { get; set; }
        public BannerPosition Position { get; set; }

        [Display(Name = "عکس")]
        //[FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? ImageFile { get; set; } 
        public string? ImageName { get; set; }

        public async Task OnGet(long id)
        {
            var result=await _bannerService.GetBannerById(id);
            Link = result.Link;
            Position=result.Position;
            ImageName = result.ImageName;
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result =await _bannerService.EditBanner(new EditBannerCommand()
            {
                Id = id,
                ImageFile = ImageFile,
                Position = Position,
                Link = Link
            });
            return RedirectAndShowAlert(result,RedirectToPage("index"));
        }
    }
}

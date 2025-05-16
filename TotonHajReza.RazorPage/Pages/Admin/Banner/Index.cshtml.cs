using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Banners;
using TotonHajReza.RazorPage.Services.Banners;

namespace TotonHajReza.RazorPage.Pages.Admin.Banner
{
    public class IndexModel : BaseRazorPage
    {
        private readonly IBannerService _bannerService;

        public IndexModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public List<BannerDto> Banners { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Banners = await _bannerService.GetList();
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(long bannerId)
        {
            if (bannerId <= 0)
            {
                ModelState.AddModelError(string.Empty, "شناسه اسلایدر نامعتبر است.");
                return Page();
            }
            var result = await _bannerService.DeleteBanner(bannerId);
            return RedirectAndShowAlert(result, RedirectToPage("index"));
        }
    }
}

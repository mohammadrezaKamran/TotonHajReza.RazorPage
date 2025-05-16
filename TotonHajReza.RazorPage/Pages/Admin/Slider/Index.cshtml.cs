using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Slider;
using TotonHajReza.RazorPage.Services.Slider;

namespace TotonHajReza.RazorPage.Pages.Admin.Slider
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        public IndexModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public List<SliderDto> Sliders { get; set; }
        public async Task OnGet()
        {
            Sliders= await _sliderService.GetSliderList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(long sliderId)
        {
            if (sliderId <= 0)
            {
                ModelState.AddModelError(string.Empty, "شناسه اسلایدر نامعتبر است.");
                return Page();
            }
            var result=  await _sliderService.DeleteSlider(sliderId);

            return RedirectAndShowAlert(result, RedirectToPage("index"));
           
        }
    }
}

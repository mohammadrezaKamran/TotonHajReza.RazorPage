using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using TotonHajReza.RazorPage.Services.Slider;

namespace TotonHajReza.RazorPage.Pages.Admin.Slider
{
    [BindProperties]
    public class AddModel : BaseRazorPage
    {

        private readonly ISliderService _sliderService;

        public AddModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Url)]
        public string Link { get; set; }

        [Display(Name = "عکس اسلایدر")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile ImageFile { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var result = await _sliderService.CreateSlider(new Models.Slider.CreateSliderCommand()
            {
                Link = Link,
                ImageFile = ImageFile,
                Title = Title
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}

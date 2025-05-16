using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using TotonHajReza.RazorPage.Services.Slider;

namespace TotonHajReza.RazorPage.Pages.Admin.Slider
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        public EditModel(ISliderService sliderService)
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
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? ImageFile { get; set; }


        public string? ImageName { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            var slider = await _sliderService.GetSliderById(id);

            if (slider == null)
                return RedirectToPage("Index");

            Link = slider.Link;
            Title= slider.Title;
            ImageName = slider.ImageName;

            return Page();
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _sliderService.EditSlider(new Models.Slider.EditSliderCommand()
            {
                Id=id,
                Link = Link,
                Title = Title,
                ImageFile = ImageFile,
            });
            return RedirectAndShowAlert(result, RedirectToPage("index"));
        }
    }
}

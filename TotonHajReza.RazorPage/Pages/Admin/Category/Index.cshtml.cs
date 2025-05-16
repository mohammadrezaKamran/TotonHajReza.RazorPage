using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Category;
using TotonHajReza.RazorPage.Services.Category;

namespace TotonHajReza.RazorPage.Pages.Admin.Category
{
    [BindProperties]
    public class IndexModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryDto> Categories { get; set; }
        public async Task OnGet()
        {
            Categories=await _categoryService.GetCategories();
        }

     
            public async Task<IActionResult> OnPostDeleteAsync(long categoryId)
            {
                if (categoryId <= 0)
                {
                    ModelState.AddModelError(string.Empty, "شناسه اسلایدر نامعتبر است.");
                    return Page();
                }
                var result = await _categoryService.DeleteCategory(categoryId);

                return RedirectAndShowAlert(result, RedirectToPage("index"));

            }
        
    }
}

﻿using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Services.Category;

namespace TotonHajReza.RazorPage.Pages.Admin.Products
{
    public class IndexModel : BaseRazorFilter<ProductFilterParams>
    {
        private IProductService _productService;
        private readonly ICategoryService _categoryService;
        public IndexModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ProductFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _productService.GetProductByFilter(FilterParams);
        }


        public async Task<IActionResult> OnGetLoadChildCategories(long parentId)
        {
            var options = "<option value='0'>انتخاب کنید</option>";
            var child = await _categoryService.GetChild(parentId);
            child.ForEach(f =>
            {
                options += $"<option value='{f.Id}'>{f.Title}</option>";
            });
            return Content(options.Trim());
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Models.Products.Commands;
using TotonHajReza.RazorPage.Services.Products;
using TotonHajReza.RazorPage.ViewModels;

namespace TotonHajReza.RazorPage.Pages.Admin.Products;

[BindProperties]
public class EditModel : BaseRazorPage
{
    private IProductService _productService;

    public EditModel(IProductService productService)
    {
        _productService = productService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "عکس محصول")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [UIHint("Ckeditor4")]
    public string Description { get; set; }

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(1, long.MaxValue, ErrorMessage = "دسته بندی را وارد کنید")]
    public long CategoryId { get; set; }

    [Display(Name = "زیردسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(1, long.MaxValue, ErrorMessage = "زیر دسته بندی را وارد کنید")]
    public long SubCategoryId { get; set; }

    [Display(Name = "دسته بندی سوم")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public long? SecondarySubCategoryId { get; set; }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }

    [Display(Name = "BrandName")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string BrandName
    {
        get => _brandName;
        set => _brandName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.Trim().ToLower());
    }
    private string _brandName;
    public ProductStatus Status { get; set; }

    public SeoDataViewModel SeoData { get; set; }

    public List<string> Keys { get; set; } = new();
    public List<string> Values { get; set; } = new();
    public async Task<IActionResult> OnGet(long productId)
    {
        var product = await _productService.GetProductById(productId);
        if (product == null)
            return RedirectToPage("Index");

        
        Title = product.Title;
        Slug = product.Slug;
        Description = product.Description;
        SeoData=SeoDataViewModel.MapSeoDataToViewModel(product.SeoData);
        CategoryId = product.Category.Id;
        SubCategoryId = product.SubCategory.Id;
        SecondarySubCategoryId = product.SecondarySubCategory?.Id;
        Status = product.Status;
        BrandName=product.BrandName;
        InitSpecifications(product.Specifications);
        return Page();
    }

    public async Task<IActionResult> OnPost(long productId)
    {
        var result = await _productService.EditProduct(new EditProductCommand()
        {
            Title = Title,
            SeoData = SeoData.MapToSeoData(),
            Slug = Slug,
            ImageFile = ImageFile,
            SecondarySubCategoryId = SecondarySubCategoryId,
            CategoryId = CategoryId,
            SubCategoryId = SubCategoryId,
            Description = Description,
            BrandName = BrandName,
            Status = Status,
            ProductId = productId,
            Specifications = ConvertSpecifications()
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }

    public void InitSpecifications(List<ProductSpecificationDto> specifications)
    {
        foreach (var specification in specifications)
        {
            Keys.Add(specification.Key);
            Values.Add(specification.Value);
        }
    }
    private Dictionary<string, string> ConvertSpecifications()
    {
        var specifications = new Dictionary<string, string>();
        Keys.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
        Values.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
        for (var i = 0; i < Keys.Count; i++)
        {
            specifications.Add(Keys[i], Values[i]);
        }

        return specifications;
    }
}
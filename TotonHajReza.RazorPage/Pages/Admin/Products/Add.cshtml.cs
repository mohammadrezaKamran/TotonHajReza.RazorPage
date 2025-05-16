using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using TotonHajReza.RazorPage.Models.Products.Commands;
using TotonHajReza.RazorPage.Services.Products;
using TotonHajReza.RazorPage.ViewModels;

namespace TotonHajReza.RazorPage.Pages.Admin.Products;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IProductService _productService;

    public AddModel(IProductService productService)
    {
        _productService = productService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "عکس محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile ImageFile { get; set; }

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

    //[Display(Name = "کد رنگ")]
    //[Required(ErrorMessage = "{0} را وارد کنید")]
    //[RegularExpression(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "کد رنگ باید به صورت HEX معتبر باشد (مثلاً #FFFFFF یا #FFF)")]
    //public string ColorHex { get; set; } = "#000000";


    [Display(Name = "BrandName")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string BrandName
    {
        get => _brandName;
        set => _brandName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.Trim().ToLower());
    }
    private string _brandName;
    public SeoDataViewModel SeoData { get; set; }

    public List<string> Keys { get; set; } = new();
    public List<string> Values { get; set; } = new();
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (SecondarySubCategoryId == 0)
            SecondarySubCategoryId = null;

        var result = await _productService.CreateProduct(new CreateProductCommand()
        {
            CategoryId = CategoryId,
            Description = Description,
            ImageFile = ImageFile,
            SecondarySubCategoryId = SecondarySubCategoryId,
            SeoData = SeoData.MapToSeoData(),
            Slug = Slug,
            Specifications = ConvertSpecifications(),
            SubCategoryId = SubCategoryId,
            Title = Title,
            BrandName = BrandName,
        });

        return RedirectAndShowAlert(result, RedirectToPage("Index"));
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
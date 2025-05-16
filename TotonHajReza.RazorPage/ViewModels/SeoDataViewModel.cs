using System.ComponentModel.DataAnnotations;
using TotonHajReza.RazorPage.Models;

namespace TotonHajReza.RazorPage.ViewModels;

public class SeoDataViewModel
{
    [Display(Name = "عنوان صفحه")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string MetaTitle { get; set; }

    [DataType(DataType.MultilineText)]
    public string? MetaDescription { get; set; } = "";

    public string? MetaKeyWords { get; set; } = "";
    public bool IndexPage { get; set; }

    [Display(Name = "لینک کنونیکال")]
    [DataType(DataType.Url)]
    [MaxLength(2083, ErrorMessage = "طول {0} نمی‌تواند بیشتر از 2083 کاراکتر باشد")]
    [RegularExpression(@"^(https?://)?([\da-z\.-]+)\.([a-z\.]{2,6})([/\w \.-]*)*/?$",
       ErrorMessage = "فرمت {0} معتبر نیست")]
    public string? Canonical { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Schema { get; set; } = "";

    public SeoData MapToSeoData()
    {
        return new SeoData()
        {
            Canonical = Canonical,
            IndexPage = IndexPage,
            MetaDescription = MetaDescription,
            MetaKeyWords = MetaKeyWords,
            MetaTitle = MetaTitle,
            Schema = Schema
        };
    }

    public static SeoDataViewModel MapSeoDataToViewModel(SeoData seoData)
    {
        return new SeoDataViewModel()
        {
            Canonical = seoData.Canonical,
            IndexPage = seoData.IndexPage,
            MetaDescription = seoData.MetaDescription,
            MetaKeyWords = seoData.MetaKeyWords,
            MetaTitle = seoData.MetaTitle,
            Schema = seoData.Schema
        };
    }
}
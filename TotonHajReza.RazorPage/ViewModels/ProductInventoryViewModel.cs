using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Products;

namespace TotonHajReza.RazorPage.ViewModels
{
    public class ProductInventoryViewModel
    {
        [Display(Name = "موجودی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(0, 100, ErrorMessage = "{0} نمی‌تواند مقدار منفی داشته باشد")]
        public int StockQuantity { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Range(10000, 1000000000, ErrorMessage = "{0} باید بین 10,000 تا 100,000,000 تومان باشد")]
        public decimal Price { get; set; }

        [Display(Name = "تخفیف")]
        [Range(0, 100, ErrorMessage = "{0} باید بین 0 تا 100 باشد")]
        public int? DiscountPercentage { get; set; }
    }
}

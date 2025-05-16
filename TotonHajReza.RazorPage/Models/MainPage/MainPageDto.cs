using TotonHajReza.RazorPage.Models.Banners;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Models.Slider;

namespace TotonHajReza.RazorPage.Models.MainPage
{
    public class MainPageDto
    {
        public List<SliderDto> Sliders { get; set; }
        public List<BannerDto> Banners { get; set; }
        public List<ProductShopDto> SpectialProducts { get; set; }
        public List<ProductShopDto> LatestProducts { get; set; }
        public List<ProductShopDto> TopVisitProducts { get; set; }
    }
}

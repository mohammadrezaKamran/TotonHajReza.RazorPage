using Newtonsoft.Json;
using TotonHajReza.RazorPage.Models.Category;

namespace TotonHajReza.RazorPage.Models.Products;

public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterParam>
{
    public CategoryDto? CategoryDto { get; set; }
}

public class ProductShopDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string BrandName { get; set; }
    public string ColorHex { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public int? DiscountPercentage { get; set; }
    public string ImageName { get; set; }
    public ProductStatus Status { get; set; }

    public int TotalPrice { get; set; }
}
public class ProductShopFilterParam : BaseFilterParam
{
    public string? CategorySlug { get; set; } = "";
    public string? Search { get; set; } = "";
    public bool OnlyAvailableProducts { get; set; } = false;
    public bool? JustHasDiscount { get; set; } = false;
    public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
}

public enum ProductSearchOrderBy
{
    Latest,
    Expensive,
    Cheapest,
}
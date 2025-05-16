
using System.ComponentModel.DataAnnotations;

namespace TotonHajReza.RazorPage.Models.Products;

public class ProductDto : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public string BrandName { get; set; }
    public ProductCategoryDto Category { get; set; }
    public ProductCategoryDto SubCategory { get; set; }
    public ProductCategoryDto? SecondarySubCategory { get; set; }
    public List<ProductVariantDto> ProductVariants { get; set; }
    public ProductStatus Status { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImageDto> Images { get; set; }
    public List<ProductSpecificationDto> Specifications { get; set; }
}

public class ProductCategoryDto
{
    public long Id { get; set; }
    public long? ParentId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}
public enum ProductStatus
{

    Published,

    Disabled
}
public enum ProductVariantStatus
{

    Active,

    InActive,

    OutOfStock,

    LowStock,

    Deleted,
}
public enum NicotineLevelEnum
{

    Light,
    Medium,
    Heavy
}

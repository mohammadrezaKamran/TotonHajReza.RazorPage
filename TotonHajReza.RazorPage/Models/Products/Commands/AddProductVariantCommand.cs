
namespace TotonHajReza.RazorPage.Models.Products.Commands;

public class AddProductVariantCommand
{
    public long ProductId { get; set; }
    public string SKU { get; set; }
    public string? Color { get; set; }
    public string? Weight { get; set; }
    public NicotineLevelEnum? NicotineLevel { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public int? DiscountPercentage { get; set; }
    public ProductVariantStatus Status { get; set; }
}
public class EditProductVariantCommand
{
    public long ProductVariantId { get; set; }
    public long ProductId { get; set; }
    public string SKU { get; set; }
    public string? Color { get; set; }
    public string? Weight { get; set; }
    public NicotineLevelEnum? NicotineLevel { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public int? DiscountPercentage { get; set; }
    public ProductVariantStatus Status { get; set; }
}
public class EditProductVariantStatusCommand
{
    public long ProductVariantId { get; set; }
    public ProductVariantStatus Status { get; set; }
}

namespace TotonHajReza.RazorPage.Models.Products;

public class ProductVariantDto
{
    public long Id { get; set; }
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
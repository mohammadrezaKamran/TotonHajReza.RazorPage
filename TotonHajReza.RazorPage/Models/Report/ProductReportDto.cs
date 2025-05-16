using TotonHajReza.RazorPage.Models.Products;

public class ProductReportDto
{
    public long ProductId { get; set; }
    public string Title { get; set; }
    public List<ProductVariantReportDto> Variants { get; set; }
}


public class ProductVariantReportDto
{
    public long VariantId { get; set; }
    public string? Color { get; set; }
    public string? Weight { get; set; }
    public NicotineLevelEnum? NicotineLevel { get; set; }
    public int TotalSold { get; set; }
    public decimal TotalRevenue { get; set; }

}
public class ProductSalesDto
{
    public long ProductId { get; set; }
    public string SKU { get; set; }
    public int TotalSold { get; set; }
}
public class OutOfStockProductDto
{
    public long ProductId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string SKU { get; set; }
    public string? Weight { get; set; }
    public NicotineLevelEnum? NicotineLevel { get; set; }
    public int StockQuantity { get; set; }
}
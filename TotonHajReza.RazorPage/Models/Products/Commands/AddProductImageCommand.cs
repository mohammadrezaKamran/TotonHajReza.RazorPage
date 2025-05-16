namespace TotonHajReza.RazorPage.Models.Products.Commands;

public class AddProductImageCommand
{
    public IFormFile ImageFile { get; set; }
    public long ProductId { get; set; }
    public int Sequence { get; set; }
}
public class AddInventoryCommand
{
    public long ProductId { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price {  get; set; }
    public int? PercentageDiscount {  get; set; }
}
public class EditInventoryCommand
{
    public long InventoryId { get; set; }
    public long ProductId { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public int? PercentageDiscount { get; set; }
}
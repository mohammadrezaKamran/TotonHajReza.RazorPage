namespace TotonHajReza.RazorPage.Models.Orders.Command;

public class AddOrderItemCommand
{
    public long ProductVariantId { get; set; }
    public long UserId { get; set; }
    public int Count { get; set; }
}
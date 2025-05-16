namespace TotonHajReza.RazorPage.Models.Users.Commands;

public class ChangePasswordCommand
{
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class AddToWishListCommand
{
    public long UserId {  get; set; }
    public long ProductId {  get; set; }
}
public class RemoveWishListCommand
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
}
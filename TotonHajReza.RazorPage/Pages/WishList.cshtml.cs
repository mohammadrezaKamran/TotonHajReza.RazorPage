using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Services.Users;

namespace TotonHajReza.RazorPage.Pages
{
    public class WishListModel : PageModel
    {
        private readonly IUserService _userService;

        public WishListModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<ProductDto> Products { get; set; }

        public async Task OnGet()
        {
            Products = await _userService.GetWishList();
        }
    }
}

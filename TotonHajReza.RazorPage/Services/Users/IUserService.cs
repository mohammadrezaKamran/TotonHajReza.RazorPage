using Microsoft.AspNetCore.Mvc.ApplicationModels;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Models.Users;
using TotonHajReza.RazorPage.Models.Users.Commands;

namespace TotonHajReza.RazorPage.Services.Users
{
    public interface IUserService
    {
        Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams);
        Task<UserDto?> GetUserById(long UserId);
        Task<UserDto?> GetCurrentUser();
        Task<List<ProductDto?>> GetWishList();

        Task<ApiResult> CreateUser(CreateUserCommand command);
        Task<ApiResult> EditCurrentUser(EditUserCommand command);
        Task<ApiResult> ChangePassword(ChangePasswordCommand command);
        Task<ApiResult> EditUser(EditUserCommand command);
        Task<ApiResult> AddToWishList(AddToWishListCommand command);
        Task<ApiResult> RemoveWishList(RemoveWishListCommand command);
    }
}

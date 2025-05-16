using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.UserAddress;

namespace TotonHajReza.RazorPage.Services.UserAddress
{
    public interface IUserAddressService
    {
        Task<AddressDto?> GetUserAddress();
        Task<AddressDto?> GetUserAddressById(long id);

        Task<ApiResult> CreateUserAddress(CreateUserAddressCommand command);
        Task<ApiResult> EditUserAddress(EditUserAddressCommand command);
    }
}

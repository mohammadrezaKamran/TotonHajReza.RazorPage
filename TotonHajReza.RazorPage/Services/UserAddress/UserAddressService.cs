using System.Runtime.Loader;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.UserAddress;

namespace TotonHajReza.RazorPage.Services.UserAddress
{
    public class UserAddressService : IUserAddressService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "UserAddress";

        public UserAddressService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> CreateUserAddress(CreateUserAddressCommand command)
        {
           var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
           
        }

        public async Task<ApiResult> EditUserAddress(EditUserAddressCommand command)
        {
            var result = await _client.PutAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<AddressDto?> GetUserAddressById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<AddressDto>>($"{ModuleName}/{id}");
            return result.Data;
        }

        public async Task<AddressDto?> GetUserAddress()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<AddressDto>>(ModuleName);
            return result.Data;
        }
    }
}

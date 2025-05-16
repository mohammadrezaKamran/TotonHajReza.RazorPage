using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System;
using TotonHajReza.RazorPage.Infrastructure;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Models.Users;
using TotonHajReza.RazorPage.Models.Users.Commands;

namespace TotonHajReza.RazorPage.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        private const string ModuleName = "Users";

        public async Task<ApiResult> ChangePassword(ChangePasswordCommand command)
        {
            var result=await _client.PutAsJsonAsync($"{ModuleName}/ChangePassword", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();

        }

        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditCurrentUser(EditUserCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");

            if (command.Avatar != null)
                formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar", command.Avatar.FileName);

            formData.Add(new StringContent(command.Gender.ToString()), "Gender");
            formData.Add(new StringContent(command.Name), "Name");
            formData.Add(new StringContent(command.Family), "Family");
            formData.Add(new StringContent(command.Email), "Email");

            var result = await _client.PutAsync($"{ModuleName}/current", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditUser(EditUserCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");
            formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar", command.Avatar.FileName);
            formData.Add(new StringContent(command.Gender.ToString()), "Gender");
            formData.Add(new StringContent(command.Name), "Name");
            formData.Add(new StringContent(command.Family), "Family");
            formData.Add(new StringContent(command.Email), "Email");

            var result = await _client.PutAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<UserDto?> GetCurrentUser()
        {
            var result=await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/current");
            return result.Data;
        }

        public async Task<UserDto?> GetUserById(long UserId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/{UserId}");
            return result.Data;
        }

        public async Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams)
        {

            var url = filterParams.GenerateBaseFilterUrl(ModuleName) +
                $"email={filterParams.Email}&phoneNumber={filterParams.PhoneNumber}&id={filterParams.Id}";
            var result = await _client.GetFromJsonAsync<ApiResult<UserFilterResult>>(url);
            return result.Data;
        }

        public async Task<List<ProductDto?>> GetWishList()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<ProductDto?>>>($"{ModuleName}/WishList");
            return result?.Data;
        }

        public async Task<ApiResult> AddToWishList(AddToWishListCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/WishList", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> RemoveWishList(RemoveWishListCommand command)
        {
            var result = await _client.PostAsJsonAsync($"{ModuleName}/WishList", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}

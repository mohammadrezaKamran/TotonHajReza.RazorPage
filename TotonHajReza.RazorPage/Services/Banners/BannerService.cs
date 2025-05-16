using TotonHajReza.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Banners;

namespace TotonHajReza.RazorPage.Services.Banners
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Banner";
        public BannerService(HttpClient client )
        {
            _client = client;
        }

        public async Task<ApiResult> CreateBanner(CreateBannerCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            formData.Add(new StringContent(command.Position.ToString()), "Position");

            var result = await _client.PostAsync(ModuleName, formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteBanner(long bannerId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{bannerId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        
        }

        public async Task<ApiResult> EditBanner(EditBannerCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Link), "Link");
            if (command.ImageFile != null && command.ImageFile.IsImage())
                formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            formData.Add(new StringContent(command.Position.ToString()), "Position");
            formData.Add(new StringContent(command.Id.ToString()), "Id");

            var result = await _client.PutAsync(ModuleName, formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<BannerDto?> GetBannerById(long bannerId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<BannerDto>>($"{ModuleName}/{ bannerId}");
            return result?.Data ;
        }

        public async Task<List<BannerDto>> GetList()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<BannerDto>>>(ModuleName);
         
            if (result?.Data == null)
                   return new List<BannerDto>();

            return result?.Data ;
        }
    }
}

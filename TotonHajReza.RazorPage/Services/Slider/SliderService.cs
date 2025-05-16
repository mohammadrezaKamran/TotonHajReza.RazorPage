using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Slider;

namespace TotonHajReza.RazorPage.Services.Slider
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "slider";
        public SliderService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<ApiResult> CreateSlider(CreateSliderCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Title), "Title");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            formData.Add(new StringContent(command.Link), "Link");

            var result = await _client.PostAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();


        }

        public async Task<ApiResult> DeleteSlider(long SliderId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{SliderId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditSlider(EditSliderCommand command)
        {
            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(command.Title), "Title");
            formData.Add(new StringContent(command.Link), "Link");
            formData.Add(new StringContent(command.Id.ToString()), "Id");

            if (command.ImageFile != null)
                 formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);

            var result = await _client.PutAsync(ModuleName, formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<SliderDto?> GetSliderById(long SliderId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<SliderDto?>>($"{ModuleName}/{SliderId}");
            return result.Data;
        }

        public async Task<List<SliderDto>> GetSliderList()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<SliderDto?>>>(ModuleName);
            return result.Data;
        }
    }
}

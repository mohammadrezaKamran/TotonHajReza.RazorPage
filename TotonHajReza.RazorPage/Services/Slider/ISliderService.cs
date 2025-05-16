using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Slider;

namespace TotonHajReza.RazorPage.Services.Slider
{
    public interface ISliderService
    {
        Task<ApiResult> CreateSlider(CreateSliderCommand command);
        Task<ApiResult> EditSlider(EditSliderCommand command);
        Task<ApiResult> DeleteSlider(long SliderId);

        Task<List<SliderDto>> GetSliderList();
        Task<SliderDto?> GetSliderById(long SliderId);
    }
}

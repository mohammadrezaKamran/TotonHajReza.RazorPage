using System.Buffers.Text;
using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Banners;

namespace TotonHajReza.RazorPage.Services.Banners
{
    public interface IBannerService
    {
        Task<ApiResult> CreateBanner(CreateBannerCommand command);
        Task<ApiResult> EditBanner(EditBannerCommand command);
        Task<ApiResult> DeleteBanner(long bannerId);

        Task<BannerDto?> GetBannerById(long bannerId);
        Task<List<BannerDto>> GetList();
    }
}

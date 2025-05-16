using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Products;
using TotonHajReza.RazorPage.Models.Products.Commands;

namespace TotonHajReza.RazorPage.Services.Products
{
    public interface IProductService
    {
        Task<ApiResult> CreateProduct(CreateProductCommand command);
        Task<ApiResult> EditProduct(EditProductCommand command);
        Task<ApiResult> AddImage(AddProductImageCommand command);
        Task<ApiResult> DeleteProductImage(DeleteProductImageCommand command);

        Task<ApiResult> AddProductVariant(AddProductVariantCommand command);
        Task<ApiResult> EditProductVariant(EditProductVariantCommand command);
        Task<ApiResult> RemoveProductVariant(long productId,long ProductVariantId);
        Task<ApiResult> ChangeProductVariantStatus(EditProductVariantStatusCommand command);

        Task<ProductDto?> GetProductById(long productId);
        Task<ProductDto?> GetProductBySlug(string slug);
        Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams);
        Task<ProductShopResult> GetProductForShop(ProductShopFilterParam filterParams);
    }
}

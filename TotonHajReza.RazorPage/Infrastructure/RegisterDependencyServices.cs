using TotonHajReza.RazorPage.Services.Auth;
using TotonHajReza.RazorPage.Services.Banners;
using TotonHajReza.RazorPage.Services.Category;
using TotonHajReza.RazorPage.Services.MainPage;
using TotonHajReza.RazorPage.Services.Orders;
using TotonHajReza.RazorPage.Services.Products;
using TotonHajReza.RazorPage.Services.Roles;
using TotonHajReza.RazorPage.Services.Slider;
using TotonHajReza.RazorPage.Services.UserAddress;
using TotonHajReza.RazorPage.Services.Users;

namespace TotonHajReza.RazorPage.Infrastructure
{
    public static class RegisterDependencyServices
    {
        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            var baseAddress = "https://localhost:7257/api/";

            services.AddHttpContextAccessor();

            services.AddScoped<IMainPageService,MainPageService>();

            services.AddScoped<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAuthService, AuthService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IUserService, UserService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IUserAddressService, UserAddressService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IBannerService, BannerService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IRoleService, RoleService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<ISliderService, SliderService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IProductService, ProductService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IOrderService, OrderService>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

        
            return services;
        }

    }
}

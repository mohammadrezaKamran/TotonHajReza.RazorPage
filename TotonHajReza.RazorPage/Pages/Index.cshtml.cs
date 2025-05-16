using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using TotonHajReza.RazorPage.Models.MainPage;
using TotonHajReza.RazorPage.Services.Auth;
using TotonHajReza.RazorPage.Services.MainPage;

namespace TotonHajReza.RazorPage.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAuthService _authService;
        private readonly IMainPageService _mainPageService;
        private readonly IMemoryCache _memoryCache;

        public IndexModel(ILogger<IndexModel> logger, IAuthService authService, IMainPageService mainPageService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _authService = authService;
            _mainPageService = mainPageService;
            _memoryCache = memoryCache;
        }

        public MainPageDto MainPageData { get; set; }
        public async Task OnGet()
        {
            MainPageData = await _memoryCache.GetOrCreateAsync("main-page", (entry) => {
                entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15);
                entry.SlidingExpiration=TimeSpan.FromMinutes(10);
                return _mainPageService.GetMainPageData();
            });
            
        }
    }
}

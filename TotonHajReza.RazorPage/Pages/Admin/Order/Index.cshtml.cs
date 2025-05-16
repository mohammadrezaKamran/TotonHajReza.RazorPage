using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.Utils;
using TotonHajReza.RazorPage.Models.Orders;
using TotonHajReza.RazorPage.Services.Orders;

namespace TotonHajReza.RazorPage.Pages.Admin.Order
{
    public class IndexModel : PageModel
    {
        private IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

      
        [BindProperty(SupportsGet = true)]
        public OrderFilterParams FilterParams { get; set; }

        public OrderFilterResult FilterResult { get; set; }

        public async Task OnGet(string? startDate, string? endDate)
        {
            if (string.IsNullOrWhiteSpace(startDate) == false)
                FilterParams.StartDate = startDate.ToMiladi();


            if (string.IsNullOrWhiteSpace(endDate) == false)
                FilterParams.StartDate = endDate.ToMiladi();

            FilterParams.Take = 1;
            FilterResult = await _orderService.GetOrders(FilterParams);

        }
    }

}


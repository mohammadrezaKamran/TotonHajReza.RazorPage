using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Orders;
using TotonHajReza.RazorPage.Services.Orders;

namespace TotonHajReza.RazorPage.Pages.Profile.Orders
{
    public class IndexModel : BaseRazorPage
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public OrderFilterResult FilterResult { get; set; }
        public async Task OnGet(int pageId = 1, OrderStatus? status = null)
        {
            FilterResult = await _orderService.GetUserOrders(pageId, 10, status);
        }

      
            public string GetStatusClass(string status)
            {
                if (string.IsNullOrEmpty(status)) return "StatusIsNull";

                return status.ToLower()
                 switch
                {
                    "pending" => "process",
                    "Rejected" => "canceled",
                    "Finally" => "delivered",
                    _ => "default-class",
                };
            }

    }
}

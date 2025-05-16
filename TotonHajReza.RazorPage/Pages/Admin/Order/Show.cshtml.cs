using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TotonHajReza.RazorPage.Infrastructure.RazorUtils;
using TotonHajReza.RazorPage.Models.Orders;
using TotonHajReza.RazorPage.Services.Orders;

namespace TotonHajReza.RazorPage.Pages.Admin.Order
{
    public class ShowModel : BaseRazorPage
    {
        private IOrderService _orderService;

        public ShowModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public OrderDto Order { get; set; }
        public async Task<IActionResult> OnGet(long id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
                return RedirectToPage("Index");


            Order = order;
            return Page();
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _orderService.SendOrder(id);
            return RedirectAndShowAlert(result, RedirectToPage("Show", new { id }));
        }
    }
}

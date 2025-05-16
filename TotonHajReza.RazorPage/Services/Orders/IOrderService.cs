﻿using TotonHajReza.RazorPage.Models;
using TotonHajReza.RazorPage.Models.Orders;
using TotonHajReza.RazorPage.Models.Orders.Command;

namespace TotonHajReza.RazorPage.Services.Orders;

public interface IOrderService
{
    Task<ApiResult> AddOrderItem(AddOrderItemCommand command);
    Task<ApiResult> CheckoutOrder(CheckOutOrderCommand command);
    Task<ApiResult> IncreaseOrderItem(IncreaseOrderItemCountCommand command);
    Task<ApiResult> DecreaseOrderItem(DecreaseOrderItemCountCommand command);
    Task<ApiResult> DeleteOrderItem(DeleteOrderItemCommand command);
    Task<ApiResult> SendOrder(long orderId);


    Task<OrderDto?> GetOrderById(long orderId);
    Task<OrderDto?> GetCurrentOrder();
    Task<OrderFilterResult> GetOrders(OrderFilterParams filterParams);
    Task<OrderFilterResult> GetUserOrders(int pageId, int take, OrderStatus? orderStatus);

}
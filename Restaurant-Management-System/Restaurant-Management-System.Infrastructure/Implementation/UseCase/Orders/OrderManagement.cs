using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.Orders;
using Restaurant_Management_System.Application.UseCase.Orders.Dtos;
using Restaurant_Management_System.Application.UseCase.Orders.Parameters;
using Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Domain.Entities.Enum;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Orders
{
    public class OrderManagement : IOrderManagement
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IInventoryItemRepository _inventoryItemRepository;
        

        public OrderManagement
            (
                IOrderRepository orderRepository, 
                IMenuItemRepository menuItemRepository,
                IInventoryItemRepository inventoryItemRepository
            )
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public async Task<ApiResponse> GetSalesReportAsync(SalesReportQueryParameters parameters)
        {
            Expression<Func<Order, bool>> condition = o => !o.IsDeleted;

            if (parameters.From.HasValue)
                condition = condition.And(o => o.OrderDate >= parameters.From.Value);

            if (parameters.To.HasValue)
                condition = condition.And(o => o.OrderDate <= parameters.To.Value);

            var grouped = await _orderRepository.GetRangeByConditionAsync(
                condition,
                parameters,
                o => o.OrderDate.Date,
                g => new SalesReportDto
                {
                    Date = g.Key,
                    TotalOrders = g.Count(),
                    TotalRevenue = g.Sum(o => o.TotalPrice)
                });

            return ApiResponse.Success(grouped);
        }



        public async Task<ApiResponse> CreateOrderAsync(CreateOrderDto dto)
        {
            var order = dto.MapTo();
            decimal totalPrice = 0;
            List<OrderItem> orderItems = new();

            var menuItemIds = dto.OrderItems.Select(x => x.MenuItemId).Distinct().ToList();
            var menuItems = await _menuItemRepository
                .GetRangeByConditionAsync(m => menuItemIds.Contains(m.Id), includes: i => i.MenuItemInventories);

            var menuItemDict = menuItems.ToDictionary(m => m.Id);

            var inventoryItemIds = menuItems
                .SelectMany(m => m.MenuItemInventories)
                .Select(i => i.InventoryItemId)
                .Distinct()
                .ToList();

            var quantitiesDict = await _inventoryItemRepository.GetQuantitiesMap(inventoryItemIds);

            var inventoryDeductionMap = new Dictionary<int, double>();

            foreach (var item in dto.OrderItems)
            {
                if (!menuItemDict.TryGetValue(item.MenuItemId, out var menuItem))
                    return ApiResponse.Fail("Invalid Menu Item");

                foreach (var inventoryItem in menuItem.MenuItemInventories)
                {
                    var totalRequired = inventoryItem.QuantityUsed * item.Quantity;

                    if (!quantitiesDict.TryGetValue(inventoryItem.InventoryItemId, out var availableQuantity))
                        return ApiResponse.Fail("Inventory item not found");

                    if (totalRequired > availableQuantity)
                        return ApiResponse.Fail($"{menuItem.Name} is not available right now");

                    if (inventoryDeductionMap.ContainsKey(inventoryItem.InventoryItemId))
                        inventoryDeductionMap[inventoryItem.InventoryItemId] += totalRequired;
                    else
                        inventoryDeductionMap[inventoryItem.InventoryItemId] = totalRequired;
                }

                var orderItem = item.MapTo(menuItem.Price);
                totalPrice += orderItem.TotalPrice;
                orderItems.Add(orderItem);
            }

            order.TotalPrice = totalPrice;
            order.OrderItems = orderItems;

            foreach (var (inventoryItemId, quantityToDeduct) in inventoryDeductionMap)
            {
                var invItem = await _inventoryItemRepository.GetByIdAsync(inventoryItemId);
                await _inventoryItemRepository.DecreaseQuantityAsync(invItem, quantityToDeduct);
            }

            await _orderRepository.CreateAsync(order);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> GetAllOrdersAsync(OrderQueryParameters parameters)
        {
            var condition = PredicateBuilder.New<Order>(o => !o.IsDeleted);

            if (parameters.Status.HasValue)
                condition = condition.And(o => o.Status == parameters.Status);

            var orders = await _orderRepository.GetRangeByConditionAsync(condition, parameters);
            var response = orders.Map(o => o.MapTo());
            return ApiResponse.Success(response);
        }

        public async Task<ApiResponse> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return ApiResponse.Fail("Order not found.");
            }
            return ApiResponse.Success(order);
        }

        public async Task<ApiResponse> RemoveOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return ApiResponse.Fail("Order not found.");
            }
            SoftDelete.Delete(order);
            await _orderRepository.UpdateAsync(order);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> UpdateOrderStatus(int orderId, enOrderStatus status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return ApiResponse.Fail("Order not found.");
            }
            order.Status = status;
            await _orderRepository.UpdateAsync(order);
            return ApiResponse.Success(null);
        }
    }
}

using OrderManagement.Domain.Entities;
using OrderManagement.Application.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<bool> CreateOrders(Order data);
        Task<AnalyzedData> DataManagement(List<OrdersData> ordersData);
    }
}

using OrderManagement.Domain.Entities;
using OrderManagement.Application.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<bool> CreateOrders(List<Order> data);
        Task<bool> CreateClients(List<Client> data);

        Task<AnalyzedDataDTO> DataManagement(List<OrdersDataDTO> ordersData);
    }
}

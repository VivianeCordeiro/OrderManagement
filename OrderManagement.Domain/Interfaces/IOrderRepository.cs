﻿using OrderManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<bool> CreateOrders (List<Order> orders);
        Task<bool> CreateClients(List<Client> clients);


    }
}

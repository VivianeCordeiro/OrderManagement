using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.InfraData.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.InfraData.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<bool> CreateOrders(Order data)
        {
            try
            {
                _context.Orders.Add(data);
                await _context.SaveChangesAsync();
                return true; // Indica que a operação foi bem-sucedida
            }
            catch (Exception ex)
            {
                return false; // Indica que a operação falhou
            }
        }
    }
       
}

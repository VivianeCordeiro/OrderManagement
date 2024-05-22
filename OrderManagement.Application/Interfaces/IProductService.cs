using OrderManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
   
        }
}

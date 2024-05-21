﻿using OrderManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        /*Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);*/
    }
}

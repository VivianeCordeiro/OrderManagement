using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Domain.Entities;
using OrderManagement.InfraData.Context;

namespace OrderManagement.InfraData.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Verifique se o banco de dados já tem dados
                if (context.Products.Any())
                {
                    return; // DB foi inicializado
                }

                context.Products.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Celular",
                        Price = 1000
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Notebook",
                        Price = 3000
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Televisão",
                        Price = 5000
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

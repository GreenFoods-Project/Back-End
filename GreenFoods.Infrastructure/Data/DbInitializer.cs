using GreenFoods.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GreenFoods.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.EnsureCreated();

                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                var products = new Product[]
                {
                    new Product{Name="Apple", Description="Fresh Apple", Price=1.20M, Image="apple.jpg"},
                    new Product{Name="Orange", Description="Juicy Orange", Price=1.50M, Image="orange.jpg"},
                    new Product{Name="Banana", Description="Ripe Banana", Price=1.10M, Image="banana.jpg"}
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }
                context.SaveChanges();
            }
        }
    }
}

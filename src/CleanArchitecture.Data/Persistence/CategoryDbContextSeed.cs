using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class CategoryDbContextSeed
    {
        public static async Task SeedAsync(CategoryDbContext context, ILogger<CategoryDbContextSeed> logger)
        {
            if (!context.Categories!.Any())
            {
                context.Categories!.AddRange(GetPreconfigureCategories());
                await context.SaveChangesAsync();
                logger.LogInformation("We have created new records");
            }
        }

        private static IEnumerable<Category> GetPreconfigureCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Category One", Url = "http://category.one"},
                new Category { Name = "Category Two", Url = "http://category.two"},
                new Category { Name = "Category Three", Url = "http://category.three"}
            };
        }
    }
}

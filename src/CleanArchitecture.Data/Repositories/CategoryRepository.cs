using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(CategoryDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Category>> GetCategoryById(int id)
        {
            return await _context.Categories!.Where(c => c.Id == id).ToListAsync();
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return await _context.Categories!.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}

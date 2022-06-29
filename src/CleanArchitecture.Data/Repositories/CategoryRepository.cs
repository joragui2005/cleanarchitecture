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
    }
}

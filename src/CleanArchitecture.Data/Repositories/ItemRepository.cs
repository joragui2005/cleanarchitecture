using System.Linq.Expressions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(CategoryDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Item>> GetItemById(int id)
        {
            return await _context.Items!.Where(c => c.Id == id).ToListAsync();
        }
    }
}

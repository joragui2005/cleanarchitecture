using System.Linq.Expressions;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(CategoryDbContext context) : base(context)
        {
        }
        public async Task<IReadOnlyList<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Item>> GetAsync(Expression<Func<Item, bool>> predicated)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Item>> GetAsync(Expression<Func<Item, bool>>? predicated = null, Func<IQueryable<Item>, IOrderedQueryable<Item>>? orderBy = null, string? includeString = null,
            bool disablesTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Item>> GetAsync(Expression<Func<Item, bool>>? predicated = null, Func<IQueryable<Item>, IOrderedQueryable<Item>>? orderBy = null, List<Expression<Func<Item, object>>>? includes = null, bool disablesTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> AddAsync(Item entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> UpdateAsync(Item entity, int id)
        {
            throw new NotImplementedException();
        }

    }
}

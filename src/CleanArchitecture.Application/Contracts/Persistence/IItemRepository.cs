using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IItemRepository : IAsyncRepository<Item>
    {
        Task<IEnumerable<Item>> GetItemById(int id);
    }
}

using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IItemRepository : IAsyncRepository<Item>
    {

    }
}

using System.Globalization;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoryById(int id);
    }
}

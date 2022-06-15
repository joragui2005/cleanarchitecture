using System.Globalization;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<Category> GetCategoryByName(string name);
        Task<IEnumerable<Category>> GetCategoryByUsername(string username);
    }
}

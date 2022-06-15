using MediatR;

namespace CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryVm>>
    {
        public int Id { get; set; }

        public GetCategoriesListQuery(int id)
        {
            Id = id;
        }
    }
}

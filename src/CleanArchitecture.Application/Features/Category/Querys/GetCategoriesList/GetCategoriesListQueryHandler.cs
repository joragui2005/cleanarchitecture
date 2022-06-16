using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Category.Querys.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoryById(request.Id);

            return _mapper.Map<List<CategoryVm>>(categories);
        }
    }
}

using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Item.Querys.GetItemsList
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, List<ItemVm>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public GetItemsListQueryHandler(IItemRepository itemRepository, ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<ItemVm>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Item> items;
            if (string.IsNullOrEmpty(request.CategoryName))

            {
                items = request.Id == 0
                    ? await _itemRepository.GetAllAsync()
                    : await _itemRepository.GetItemById(request.Id);
            }
            else
            {
                var category = await _categoryRepository.GetAsync(x => x.Name == request.CategoryName);
                items = category.Count > 0
                ? await _itemRepository.GetAsync(x => x.CategoryId == category.AsEnumerable().FirstOrDefault().Id)
                : new List<Domain.Item>();
            }

            return _mapper.Map<List<ItemVm>>(items);
        }

    }
}

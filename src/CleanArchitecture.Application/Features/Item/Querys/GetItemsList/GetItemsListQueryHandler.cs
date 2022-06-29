using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Item.Querys.GetItemsList
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, List<ItemVm>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;


        public GetItemsListQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<ItemVm>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            var items = request.Id == 0
                ? await _itemRepository.GetAllAsync()
                : await _itemRepository.GetItemById(request.Id);

            return _mapper.Map<List<ItemVm>>(items);
        }
    }
}

using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Item.Commands.Update;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Item.Commands.Delete
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateItemCommandHandler> _logger;


        public DeleteItemCommandHandler(IItemRepository itemRepository, IMapper mapper,
            ILogger<UpdateItemCommandHandler> logger)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var itemEntity = await _itemRepository.GetByIdAsync(request.Id);

            if (itemEntity == null)
            {
                _logger.LogError($"Item not found, {request.Id}");
                throw new NotFoundException(nameof(Item), request.Id);
            }

            await _itemRepository.DeleteAsync(itemEntity.Id);

            _logger.LogInformation($"The item id:{itemEntity.Id}, was deleted");

            return Unit.Value;
        }
    }
}

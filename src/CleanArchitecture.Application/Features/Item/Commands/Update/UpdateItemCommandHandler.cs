using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Item.Commands.Update
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateItemCommandHandler> _logger;


        public UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper,
            ILogger<UpdateItemCommandHandler> logger)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var itemEntity = await _itemRepository.GetByIdAsync(request.Id);

            if (itemEntity == null)
            {
                _logger.LogError($"Item not found, {request.Id}");
                throw new NotFoundException(nameof(Item), request.Id);
            }

            _mapper.Map(request, itemEntity, typeof(UpdateItemCommand), typeof(Domain.Item));

            await _itemRepository.UpdateAsync(itemEntity, itemEntity.Id);

            _logger.LogInformation($"The item id:{itemEntity.Id}, was updated");

            return Unit.Value;
        }
    }
}

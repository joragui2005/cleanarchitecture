
using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Item.Commands.Create
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateItemCommandHandler> _logger;


        public CreateItemCommandHandler(IItemRepository itemRepository, IMapper mapper, IEmailService emailService,
            ILogger<CreateItemCommandHandler> logger)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var itemEntity = _mapper.Map<Domain.Item>(request);
            var newItem = await _itemRepository.AddAsync(itemEntity);
            _logger.LogInformation($"New item id:{newItem.Id}, was created");

            await SendEmail(newItem);

            return newItem.Id;
        }

        private async Task SendEmail(Domain.Item item)
        {
            var email = new Email()
            {
                To = "joragui@email.com",
                Body = $"Item created: {item.Id}",
                Subject = "Item added"
            };

            try
            {
                var wasSent = await _emailService.SendEmail(email);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error al enviar el email: {item.Id}");
                Console.WriteLine(e.Message);
            }
        }
    }
}

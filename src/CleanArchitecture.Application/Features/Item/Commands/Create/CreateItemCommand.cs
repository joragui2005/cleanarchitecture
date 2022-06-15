using MediatR;

namespace CleanArchitecture.Application.Features.Item.Commands.Create
{
    public class CreateItemCommand : IRequest<int>
    {
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}

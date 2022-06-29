using MediatR;

namespace CleanArchitecture.Application.Features.Item.Commands.Create
{
    public class CreateItemCommand : IRequest<int>
    {
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int CategoryId { get; set; }
    }
}

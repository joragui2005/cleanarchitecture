
using MediatR;

namespace CleanArchitecture.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Url { get; set; }
        public int? ParentCategory { get; set; }
    }
}

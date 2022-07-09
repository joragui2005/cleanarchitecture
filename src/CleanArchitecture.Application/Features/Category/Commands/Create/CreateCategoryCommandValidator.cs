
using FluentValidation;

namespace CleanArchitecture.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("The Name attribute is required");
            RuleFor(e => e.Url)
                .NotEmpty().WithMessage("The Url attribute is required");
        }
    }
}

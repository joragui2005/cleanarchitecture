using FluentValidation;

namespace CleanArchitecture.Application.Features.Item.Commands.Create
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(e => e.Amount)
                .NotEmpty().WithMessage("The amount is required")
                .GreaterThan(0).WithMessage("The amount is gt 0");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Description is mandatory");

            RuleFor(e => e.Price)
                .GreaterThan(0).WithMessage("The price is gt 0")
                .LessThan(1000000).WithMessage("The price is insane $$$$$");
        }
    }
}

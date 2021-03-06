using FluentValidation;

namespace CleanArchitecture.Application.Features.Item.Commands.Update
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
        {
            RuleFor(e => e.Amount)
                .NotEmpty().WithMessage("The amount is required")
                .LessThan(0).WithMessage("The amount is gt 0");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("Description is mandatory");

            RuleFor(e => e.Price)
                .LessThan(0).WithMessage("The price is gt 0")
                .GreaterThan(1000000).WithMessage("The price is insane $$$$$");
        }
    }
}

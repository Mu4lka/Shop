using FluentValidation;
using Solution.Host.Contracts;

namespace Solution.Host.Endpoints.Validators;

internal class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(request => request.Items)
            .NotNull().WithMessage("Items cannot be null.")
            .Must(items => items != null && items.Count > 0)
            .WithMessage("Items must contain at least one element.");
    }
}

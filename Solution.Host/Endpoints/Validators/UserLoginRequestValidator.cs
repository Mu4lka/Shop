using FluentValidation;
using Solution.Host.Contracts;

namespace Solution.Host.Endpoints.Validators;

internal class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(5, 100).WithMessage("Password must be between 5 and 100 characters.");
    }
}

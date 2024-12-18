using FluentValidation;
using Solution.Host.Contracts;

namespace Solution.Host.Endpoints.Validators;

internal class UserRegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(5, 100).WithMessage("Password must be between 5 and 100 characters.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(2, 100).WithMessage("First name must be between 2 and 100 characters.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname is required.")
            .Length(2, 100).WithMessage("Surname must be between 2 and 100 characters.");

        RuleFor(x => x.Patronymic)
            .Length(2, 100).WithMessage("Patronymic must be between 2 and 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.Patronymic));

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(2, 100).WithMessage("Address must be between 2 and 100 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");
    }
}
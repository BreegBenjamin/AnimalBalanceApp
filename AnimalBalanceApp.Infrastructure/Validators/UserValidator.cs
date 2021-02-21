using AnimalBalanceApp.Core.DTOs;
using AnimalBalanceApp.Core.Properties;
using FluentValidation;
using System;

namespace AnimalBalanceApp.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage(AppMessages.NameInvalidCharacters)
                .Length(1,100);

            RuleFor(user => user.LastName)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage(AppMessages.LastNameInvalidCharacteres)
                .Length(1, 100);

            RuleFor(user => user.Birthdate)
                .NotNull()
                .LessThanOrEqualTo(new DateTime(DateTime.Now.Year - 8, DateTime.Now.Month, DateTime.Now.Day))
                .WithMessage(AppMessages.InvalidUserAge);

            RuleFor(user => user.Email)
                .NotNull()
                .Length(1,100)
                .NotEmpty().WithMessage(AppMessages.EmailRequired)
                .EmailAddress().WithMessage(AppMessages.EmailInvalid);

            RuleFor(user => user.Telephone)
                .Length(0, 15)
                .Matches("^[0-9]+$");

            RuleFor(user => user.ImageName)
                .Length(1, 100);
        }
    }
}

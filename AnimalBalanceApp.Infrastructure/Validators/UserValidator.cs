using AnimalBalanceApp.Core.DTOs;
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
                .Length(1,100);

            RuleFor(user => user.LastName)
                .NotEmpty()
                .NotNull()
                .Length(1, 100);

            RuleFor(user => user.Birthdate)
                .NotNull()
                .LessThanOrEqualTo(new DateTime(DateTime.Now.Year - 8, DateTime.Now.Month, DateTime.Now.Day))
                .WithMessage("El Usuario debe tener más de 13 años");

            RuleFor(user => user.Email)
                .NotNull()
                .Length(1,100)
                .NotEmpty().WithMessage("El correo Electronico es requerido")
                .EmailAddress().WithMessage("El correo electronico es invalido");

            RuleFor(user => user.Telephone)
                .Length(0, 15);

            RuleFor(user => user.ImageName)
                .Length(1, 100);
        }
    }
}

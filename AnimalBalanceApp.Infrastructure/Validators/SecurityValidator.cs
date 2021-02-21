using AnimalBalanceApp.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Infrastructure.Validators
{
    public class SecurityValidator : AbstractValidator<SecurityDto>
    {
        public SecurityValidator()
        {
            RuleFor(security => security.SecurityUser)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9]*$")
                .Length(50);

            RuleFor(security => security.UserName)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9]*$")
                .Length(100);

            RuleFor(security => security.UserPassword)
                .NotEmpty()
                .NotNull()
                .Length(200);
        }
    }
}

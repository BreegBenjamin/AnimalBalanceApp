using AnimalBalanceApp.Core.DTOs;
using FluentValidation;
using System;

namespace AnimalBalanceApp.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.UserId)
                .NotNull()
                .GreaterThan(1);
            RuleFor(post => post.PostDescription)
                .NotNull()
                .Length(10,1000);
            RuleFor(post => post.Title)
                .NotEmpty()
                .NotNull()
                .Length(1,255);
            RuleFor(post => post.Category)
                .NotNull()
                .NotEmpty()
                .Length(1,100);
        }
    }
}

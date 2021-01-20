using AnimalBalanceApp.Core.DTOs;
using FluentValidation;

namespace AnimalBalanceApp.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.PostDescription)
                .NotNull()
                .Length(10,1000);
        }
    }
}

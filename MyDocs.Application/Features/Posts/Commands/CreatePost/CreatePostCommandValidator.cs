using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(post => post.UserId)
                .NotEmpty().WithMessage("You must create an account to create a post.")
                .NotNull();

            RuleFor(post => post.Content)
                .NotEmpty().WithMessage("The post you have created is empty")
                .NotNull();
            
        }
    }
}

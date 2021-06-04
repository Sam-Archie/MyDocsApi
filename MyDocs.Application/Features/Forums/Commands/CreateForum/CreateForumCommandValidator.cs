using FluentValidation;
using MyDocs.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Commands.CreateForum
{
    public class CreateForumCommandValidator : AbstractValidator<CreateForumCommand>
    {
        private readonly IForumRepository _forumRepository;

        public CreateForumCommandValidator(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;

        RuleFor(forum => forum.Name)
                .NotEmpty().WithMessage("Forum name is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("The forum name must not exceed 50 characters.");


            RuleFor(forum => forum)
                    .MustAsync(ForumNameIsUnique)
                    .WithMessage("The forum must have a unique name unfortunately this one already exists");

            RuleFor(forum => forum.IsPrivate)
                .NotNull();
        }

    private async Task<bool> ForumNameIsUnique(CreateForumCommand forum, CancellationToken token)
    {
        return !(await _forumRepository.IsForumNameUnique(forum.Name));
    }
    }
}

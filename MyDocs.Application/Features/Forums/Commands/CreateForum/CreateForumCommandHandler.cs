using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyDocs.Application.Contracts.Infrastructure;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Commands.CreateForum
{
    public class CreateForumCommandHandler : IRequestHandler<CreateForumCommand, Guid>
    {
        private readonly ILogger<CreateForumCommandHandler> _logger;
        private IForumRepository _forumRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public CreateForumCommandHandler(
            IMapper mapper, 
            IForumRepository forumRepository, 
            ILogger<CreateForumCommandHandler> logger, 
            IEmailService emailService,
            UserManager<User> userManager)
        {
            _logger = logger;
            _forumRepository = forumRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userManager = userManager;
        }
        public async Task<Guid> Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateForumCommandValidator(_forumRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);


            var forum = _mapper.Map<Forum>(request);
            var user = await _userManager.FindByIdAsync(request.OwnerId.ToString());
            forum = await _forumRepository.AddAsync(new Forum
            {
                ForumId = Guid.NewGuid(),
                OwnerId = Guid.Parse(user.Id),
                Name = request.Name,
                IsPrivate = request.IsPrivate
            }
        );
            return forum.ForumId;
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Commands
{
    public class CreateForumCommandHandler : IRequestHandler<CreateForumCommand, Guid>
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CreateForumCommandHandler> _logger;
        private IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public CreateForumCommandHandler(IMapper mapper, IForumRepository forumRepository, ILogger<CreateForumCommandHandler> logger, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _forumRepository = forumRepository;
            _mapper = mapper;
        }
        public Task<Guid> Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

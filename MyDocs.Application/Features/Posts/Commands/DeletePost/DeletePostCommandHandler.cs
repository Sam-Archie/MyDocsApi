using AutoMapper;
using MediatR;
using MyDocs.Application.Contracts;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Application.Exceptions;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public DeletePostCommandHandler(IMapper mapper, IAsyncRepository<Post> postRepository, ILoggedInUserService loggedInUserService)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _loggedInUserService = loggedInUserService;
        }
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postToDelete = await _postRepository.GetByIdAsync(request.PostId);

            if (postToDelete == null)
            {
                throw new NotFoundException(nameof(Post), request.PostId);
            }

            if (request.UserId != Guid.Parse(_loggedInUserService.UserId))
            {
                throw new UnauthorizedActionException("You must own this post to delete it");
            }

            await _postRepository.DeleteAsync(postToDelete);

            return Unit.Value;
        }
    }
}

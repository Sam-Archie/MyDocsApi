using AutoMapper;
using MediatR;
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

        public DeletePostCommandHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postToDelete = await _postRepository.GetByIdAsync(request.Id);

            if (postToDelete == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            await _postRepository.DeleteAsync(postToDelete);

            return Unit.Value;
        }
    }
}

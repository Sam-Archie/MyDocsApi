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

namespace MyDocs.Application.Features.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryhandler : IRequestHandler<GetPostByIdQuery, PostVm>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryhandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostVm> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post == null)
            {
                throw new NotFoundException(nameof(Post), post.Id);
            }

            return _mapper.Map<PostVm>(post);
        }
    }
}

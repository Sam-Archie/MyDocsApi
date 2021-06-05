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

namespace MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<PostListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _postRepository;

        public GetAllPostsQueryHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task <List<PostListVm>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var allPostsByDate = (await _postRepository.ListAllAsync()).OrderBy(post => post.CreatedAt);

            if (allPostsByDate == null)
                throw new NotFoundException(nameof(Post), allPostsByDate);

            return _mapper.Map<List<PostListVm>>(allPostsByDate);
        }
    }
}

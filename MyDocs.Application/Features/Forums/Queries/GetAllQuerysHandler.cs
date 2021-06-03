using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Queries
{
    public class GetAllQuerysHandler : IRequestHandler<GetAllForumsQuery, List<ForumListVm>>
    {
        private readonly IAsyncRepository<Forum> _forumRepository;
        private readonly IMapper _mapper;

        public GetAllQuerysHandler(IMapper mapper, IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
            _mapper = mapper;

        }
        public async Task<List<ForumListVm>> Handle(GetAllForumsQuery request, CancellationToken cancellationToken)
        {
            var allForumsByName = (await _forumRepository.ListAllAsync()).OrderBy(forum => forum.Name);
            return _mapper.Map<List<ForumListVm>>(allForumsByName);
        }
    }
}

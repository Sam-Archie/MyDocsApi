using MediatR;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Queries.GetListOfPostsByUserId
{
    public class GetListOfPostsByUserQueryHandler : IRequestHandler<GetListOfPostsByUserQuery, PostListVm>
    {
        public GetListOfPostsByUserQueryHandler()
        {

        }

        public Task<PostListVm> Handle(GetListOfPostsByUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

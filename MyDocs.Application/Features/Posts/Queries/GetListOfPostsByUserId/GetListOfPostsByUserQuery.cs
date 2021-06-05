using MediatR;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Queries.GetListOfPostsByUserId
{
    public class GetListOfPostsByUserQuery : IRequest<PostListVm>
    {
        public Guid UserId { get; set; }
    }
}

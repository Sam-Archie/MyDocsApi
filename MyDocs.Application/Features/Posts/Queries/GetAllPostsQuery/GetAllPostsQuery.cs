using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery
{
    public class GetAllPostsQuery : IRequest<List<PostListVm>>
    {
        
    }
}

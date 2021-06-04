using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<PostVm>
    {
        public Guid PostId { get; set; }
    }
}

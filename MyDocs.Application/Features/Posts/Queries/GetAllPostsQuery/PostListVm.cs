using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery
{
    public class PostListVm
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

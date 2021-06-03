using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Commands
{
    public class ForumDto
    {
        public string ForumId { get; set; }
        public IList<Post>? Posts { get; set; } = new List<Post>();
        public string Name { get; set; }
    }
}

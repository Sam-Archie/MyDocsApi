using MyDocs.Domain.Entities;
using System.Collections.Generic;

namespace MyDocs.Application.Features.Forums.Queries
{
    public class ForumListVm
    {
        public string ForumId { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }
    }
}
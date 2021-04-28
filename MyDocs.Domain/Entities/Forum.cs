using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Domain.Entities
{
    public class Forum
    {
        public Guid ForumId { get; set; }
        public bool IsPrivate { get; set; }
        public string Name { get; set; }
        public List<User> User { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}

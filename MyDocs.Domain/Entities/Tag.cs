using MyDocs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Domain.Entities
{
    public class Tag : FoundationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Forum> Forums { get; set; } = new List<Forum>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}

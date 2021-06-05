using MyDocs.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Domain.Entities
{
    public class Comment : FoundationEntity
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<CommentReply> Replies { get; set; } = new List<CommentReply>();
    }
}

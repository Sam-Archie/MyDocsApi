using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Persistance.Repositories
{
    public class CommentReplyRepository : FoundationRepository<CommentReply>, ICommentReplyRepository
    {
        public CommentReplyRepository(MyDocsContext dbContext) : base(dbContext)
        {

        }
    }
}

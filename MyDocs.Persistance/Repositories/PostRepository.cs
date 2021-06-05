using Microsoft.EntityFrameworkCore;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Persistance.Repositories
{
    public class PostRepository : FoundationRepository<Post>, IPostRepository
    {
        public PostRepository(MyDocsContext dbContext) : base(dbContext)
        {
           
        }
        
        public async Task<Post> GetPostById(Guid id)
        {
            var post = await _dbContext.Posts.Include(p => p.Comments)
                .ThenInclude(comment => comment.Replies)
                .Include(p => p.Tags)
                .SingleAsync(p => p.Id == id);

            return post;
        }

        public async Task<List<Post>> GetUserPosts(Guid userId)
        {
            var postList = await _dbContext.Posts.Include(p => p.Comments)
               .ThenInclude(comment => comment.Replies)
               .Include(p => p.Tags)
               .Where(p => p.UserId == userId.ToString()).ToListAsync();

            return postList;
        }
    }
}

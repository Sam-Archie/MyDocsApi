using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MyDocs.Persistance.Repositories
{
    public class ForumRepository : FoundationRepository<Forum>, IForumRepository
    {
        public ForumRepository(MyDocsContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsForumNameUnique(string name)
        {
            var matches = _dbContext.Forums.Any(forum => forum.Name.Equals(name));
            return Task.FromResult(matches);
        }
    }
}

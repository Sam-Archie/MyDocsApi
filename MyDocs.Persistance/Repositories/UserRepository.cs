using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Persistance.Repositories
{
    public class UserRepository : FoundationRepository<User>, IUserRepository
    {
        public UserRepository(MyDocsContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsUserNameAndEmailUnique(string userName, string Email)
        {
            var matches = _dbContext.Users.Any(user => user.UserName.Equals(userName) && user.Email.Equals(user.Email));
            return Task.FromResult(matches);
        }
    }
}

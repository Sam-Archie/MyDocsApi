using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Contracts.Persistance
{
    public interface IForumRepository : IAsyncRepository<Forum>
    {
    }
}

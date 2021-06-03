using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Commands
{
    public class CreateForumCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public bool IsPrivate { get; set; }
        public string Name { get; set; }
    }
}

using MediatR;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Commands.CreateForum
{
    public class CreateForumCommand : IRequest<Guid>
    {
        public Guid OwnerId { get; set; }
        public bool IsPrivate { get; set; }
        public string Name { get; set; }
    }
}

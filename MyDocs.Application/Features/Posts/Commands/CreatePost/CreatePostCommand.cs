using MediatR;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostCommandResponse>
    {
        public User UserId { get; set; }
        public string Content { get; set; }
    }
}

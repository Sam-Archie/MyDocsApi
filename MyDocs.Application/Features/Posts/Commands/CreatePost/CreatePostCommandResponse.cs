using MyDocs.Application.Features.Posts.Queries.GetPostById;
using MyDocs.Application.Responses;

namespace MyDocs.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandResponse : BaseResponse
    {
        public CreatePostCommandResponse() : base()
        {

        }
        public PostDto Post { get; set; }
    }
}
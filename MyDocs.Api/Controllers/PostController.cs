using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Application.Features.Posts.Commands.DeletePost;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Application.Features.Posts.Queries.GetPostById;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllPosts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PostListVm>>> GetAllPosts()
        {
            var listOfAllPosts = await _mediator.Send(new GetAllPostsQuery());
            return Ok(listOfAllPosts);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PostDto>> GetPostById(Guid id)
        {
            var post = await _mediator.Send(new GetPostByIdQuery() { PostId = id });
            return Ok(post);
        }

        [HttpPost("create", Name = "CreatePost")]
        //[Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            var response = await _mediator.Send(createPostCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid postId, Guid userId)
        {
            var deletePostCommand = new DeletePostCommand() { PostId = postId, UserId = userId };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }
    }
}



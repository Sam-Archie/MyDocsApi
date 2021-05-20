using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;

        public PostController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }
        [HttpGet("all", Name = "GetAllPosts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PostListVm>>> GetAllPosts()
        {
            var dtos = await _mediator.Send(new GetAllPostsQuery());
            return Ok(dtos);
        }

        private async Task<User> CurrentUser()
        {
            return await _userManager.GetUserAsync(User);
        }

        [HttpPost("create", Name = "CreatePost")]
        [Authorize]
        public async Task<ActionResult<CreatePostCommandResponse>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            createPostCommand.UserId = await CurrentUser().UserId;
            var response = await _mediator.Send(createPostCommand);
            return Ok(response);
        }
    }
}

//Put this into a controller to get the current user. Once you have this you can add this to the creatte post command



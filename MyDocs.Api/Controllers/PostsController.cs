using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Domain.Entities;
using MyDocs.Persistance;

namespace MyDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Posts
        [HttpGet("all", Name = "GetAllPosts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PostListVm>>> GetAllPosts()
        {
            var dtos = await _mediator.Send(new GetAllPostsQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "CreatePost")]
        [Authorize]
        public async Task<ActionResult<CreatePostCommandResponse>> Create([FromBody] CreatePostCommand creatPostCommand)
        {
            var response = await _mediator.Send(creatPostCommand);
            return Ok(response);
        }
    }
}


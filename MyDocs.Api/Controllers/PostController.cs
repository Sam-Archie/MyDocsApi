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

        //[HttpGet("{id}", Name = "GetPostById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<PostDto>> GetPostById(Guid id)
        //{
            
        //}

        [HttpPost("create", Name = "CreatePost")]
        //[Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            var response = await _mediator.Send(createPostCommand);
            return Ok(response);
        }
    }
}



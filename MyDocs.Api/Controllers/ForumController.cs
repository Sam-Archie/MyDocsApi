using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDocs.Application.Features.Forums.Commands.CreateForum;
using MyDocs.Application.Features.Forums.Queries.GetAllForums;
using System;
using System.Threading.Tasks;

namespace MyDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllForums")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ForumListVm>> GetAllForums()
        {
            var allForums = await _mediator.Send(new GetAllForumsQuery());
            return Ok(allForums);
        }

        [HttpPost("create", Name = "CreateForum")]
        //[Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateForumCommand createForumCommand)
        {
            var response = await _mediator.Send(createForumCommand);
            return Ok(response);
        }
    }
}

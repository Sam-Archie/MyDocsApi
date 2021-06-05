using Microsoft.AspNetCore.Mvc;
using MyDocs.Application.Contracts.Contracts.Identity;
using MyDocs.Application.Models.Authentication;
using System.Threading.Tasks;

namespace MyDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticateService;


        public UserAccountController(IAuthenticationService authenticationService)
        {
            _authenticateService = authenticationService;

        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticateService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticateService.RegisterAsync(request));
        }
    }
}

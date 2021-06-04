using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyDocs.Application.Contracts.Contracts.Identity;
using MyDocs.Application.Contracts.Infrastructure;
using MyDocs.Application.Models.Authentication;
using MyDocs.Application.Models.Mail;
using MyDocs.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDocs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticateService;
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailService> _logger;

        public UserAccountController(IAuthenticationService authenticationService, IEmailService emailService, ILogger<EmailService> logger)
        {
            _authenticateService = authenticationService;
            _emailService = emailService;
            _logger = logger;
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

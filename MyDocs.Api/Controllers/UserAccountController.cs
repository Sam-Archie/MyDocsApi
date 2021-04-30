using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDocs.Application.Contracts.Contracts.Identity;
using MyDocs.Application.Contracts.Infrastructure;
using MyDocs.Application.Models.Authentication;
using MyDocs.Application.Models.Mail;
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

        public UserAccountController(IAuthenticationService authenticationService, IEmailService emailService)
        {
            _authenticateService = authenticationService;
            _emailService = emailService;
            
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticateService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            var email = new Email()
            {
                To = request.Email,
                Subject = $"Registration",
                Body = $"Welcome to MyDocs,com thank you for registering to our application!",
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //Add some logging message here
            }

            return Ok(await _authenticateService.RegisterAsync(request));
        }
    }
}

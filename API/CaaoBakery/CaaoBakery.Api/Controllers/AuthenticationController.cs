﻿using CaaoBakery.Application.Authentication.Common;
using CaaoBakery.Application.Authentication.Commands.Register;
using CaaoBakery.Application.Authentication.Queries.Login;
using CaaoBakery.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaaoBakery.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthtenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                    authResult=> Ok(MapAutResult(authResult)),
                    errors=> Problem(errors)
                );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email,request.Password);
            ErrorOr<AuthtenticationResult> authResult = await _mediator.Send(query);

            return authResult.Match(
                    authResult => Ok(MapAutResult(authResult)),
                    errors => Problem(errors)
                );
        }

        private static AuthenticationResponse MapAutResult(AuthtenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token);
        }
    }
}

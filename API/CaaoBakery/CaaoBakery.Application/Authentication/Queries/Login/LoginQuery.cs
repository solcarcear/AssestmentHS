﻿using CaaoBakery.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CaaoBakery.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) 
        : IRequest<ErrorOr<AuthenticationResult>>;
}

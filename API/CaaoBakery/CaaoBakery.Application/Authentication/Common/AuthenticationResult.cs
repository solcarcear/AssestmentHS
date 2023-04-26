﻿using CaaoBakery.Domain.Entities;

namespace CaaoBakery.Application.Authentication.Common
{
    public record AuthenticationResult(User User,
                                         string Token);
}

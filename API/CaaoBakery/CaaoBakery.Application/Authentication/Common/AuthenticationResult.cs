using CaaoBakery.Domain.UserAggregate;

namespace CaaoBakery.Application.Authentication.Common
{
    public record AuthenticationResult(User User,
                                         string Token);
}

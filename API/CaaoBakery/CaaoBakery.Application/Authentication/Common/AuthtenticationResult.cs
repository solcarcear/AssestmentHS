using CaaoBakery.Domain.Entities;

namespace CaaoBakery.Application.Authentication.Common
{
    public record AuthtenticationResult(User user,
                                         string Token);
}

using CaaoBakery.Domain.UserAggregate;

namespace CaaoBakery.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}

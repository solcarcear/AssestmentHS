using CaaoBakery.Domain.Entities;

namespace CaaoBakery.Application.Services.Authentication
{
    public record AuthtenticationResult(User user,
                                         string Token);
}

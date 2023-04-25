using ErrorOr;

namespace CaaoBakery.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr< AuthtenticationResult> Login(string email, string password);
        ErrorOr<AuthtenticationResult> Register(string firstName,
                                         string lastName,
                                         string email,
                                         string password);
    }
}

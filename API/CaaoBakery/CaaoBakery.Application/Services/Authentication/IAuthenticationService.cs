namespace CaaoBakery.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthtenticationResult Login(string email, string password);
        AuthtenticationResult Register(string firstName,
                                         string lastName,
                                         string email,
                                         string password);
    }
}

using CaaoBakery.Application.Authentication.Commands.Register;
using CaaoBakery.Application.Authentication.Common;
using CaaoBakery.Application.Authentication.Queries.Login;
using CaaoBakery.Contracts.Authentication;
using Mapster;

namespace CaaoBakery.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest=> dest, src=> src.User);
        }
    }
}

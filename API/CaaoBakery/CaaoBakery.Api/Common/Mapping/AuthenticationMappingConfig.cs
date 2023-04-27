using CaaoBakery.Application.Authentication.Commands.Register;
using CaaoBakery.Application.Authentication.Common;
using CaaoBakery.Application.Authentication.Queries.Login;
using CaaoBakery.Contracts.Authentication;
using Mapster;

namespace CaaoBakery.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value.ToString())
                .Map(dest => dest, src => src.User);
        }
    }
}

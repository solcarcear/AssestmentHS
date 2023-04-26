using CaaoBakery.Application.Common.Interfaces.Authentication;
using CaaoBakery.Application.Persistence;
using CaaoBakery.Domain.Entities;
using CaaoBakery.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using CaaoBakery.Application.Authentication.Common;

namespace CaaoBakery.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //Validate the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;

            }

            //Validate the password
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;

            }

            //Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}

using CaaoBakery.Application.Common.Interfaces.Authentication;
using CaaoBakery.Application.Persistence;
using CaaoBakery.Domain.Entities;
using CaaoBakery.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using CaaoBakery.Application.Authentication.Common;

namespace CaaoBakery.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Check if user exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            //Create user (generate unique ID)
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };
            _userRepository.Add(user);

            //Check JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthenticationResult(user, token);
        }
    }
}

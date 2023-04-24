﻿using CaaoBakery.Application.Common.Interfaces.Authentication;
using CaaoBakery.Application.Persistence;
using CaaoBakery.Domain.Entities;

namespace CaaoBakery.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthtenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user exists
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists.");
            }

            //Create user (generate unique ID)
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            //Check JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);


            return new AuthtenticationResult(user, token);
        }

        public AuthtenticationResult Login(string email, string password)
        {
            //Validate the user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist.");

            }

            //Validate the password
            if (user.Password != password)
            {
                throw new Exception("Invalid password.");

            }

            //Create JWT token

            var token= _jwtTokenGenerator.GenerateToken(user);

            return new AuthtenticationResult(user, token);
        }
    }
}

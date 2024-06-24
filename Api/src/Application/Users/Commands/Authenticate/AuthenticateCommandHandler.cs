﻿using Domain.Users;
using System.Security.Claims;

namespace Application.Users.Commands.Authenticate
{
    public class AuthenticateCommandHandler(IUserRepository userRepository) : IAuthenticateCommandHandler
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AuthenticationResult> Handle(AuthenticateCommand command)
        {
            User user = await _userRepository.Get(command.Login);

            if (user == null)
            {
                return new AuthenticationResult("Login or password incorrect");
            }

            if (!PasswordManager.VerifyHashedPassword(user.Password, command.Password))
            {
                return new AuthenticationResult("Login or password incorrect");
            }

            return new AuthenticationResult(new UserDto(
            [
                new Claim("login", user.Login), 
                new Claim("password", user.Password)
            ]));
        }
    }
}

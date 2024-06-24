using Application.Cqrs.Commands;

namespace Application.Users.Commands.Authenticate
{
    public interface IAuthenticateCommandHandler : ICommandHandlerWithResult<AuthenticateCommand, AuthenticationResult>
    {
        
    }
}

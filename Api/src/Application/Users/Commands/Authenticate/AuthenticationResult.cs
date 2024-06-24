namespace Application.Users.Commands.Authenticate
{
    public class AuthenticationResult
    {
        public AuthenticationResult(string error)
        {
            IsAuthenticated = false;
            Error = error;
        }

        public AuthenticationResult(UserDto user)
        {
            IsAuthenticated = true;
            User = user;
        }

        public bool IsAuthenticated { get; }

        public string? Error { get; }

        public UserDto? User { get; }
    }
}

namespace WebApi.Chat.Authentication
{
    public class RegisterRequest(string login, string password, string iconUri)
    {
        public string Login { get; } = login;

        public string Password { get; } = password;

        public string IconUri { get; } = iconUri;
    }
}

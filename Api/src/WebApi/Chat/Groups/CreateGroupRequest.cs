namespace WebApi.Chat.Groups
{
    public class CreateGroupRequest(string name, string iconUri)
    {
        public string Name { get; } = name;

        public string IconUri { get; } = iconUri;
    }
}

namespace WebApi.Chat.Groups
{
    public class AddUserRequest(Guid userId, Guid groupId)
    {
        public Guid UserId { get; } = userId;

        public Guid GroupId { get; } = groupId;
    }
}

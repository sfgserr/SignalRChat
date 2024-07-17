using Domain.Groups;

namespace Infrastructure.Data.Domain.Groups
{
    internal class SeedData
    {
        public static readonly List<GroupUserPermission> Permissions = [
            new("CreateMessage"),
            new("ReadMessage"),
            new("EditMessage"),
            new("AddUser"),
            new("RemoveUser"),
            new("ChangeName"),
            new("GetGroup"),
            new("GetUserGroups"),
            new("ChangeIconUri"),
            new("GetMessages")];
    }
}

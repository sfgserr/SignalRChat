using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserRole : ValueObject
    {
        private GroupUserRole(string value, List<GroupUserPermission> permissions)
        {
            Value = value;
            Permissions = permissions;
        }

        public static GroupUserRole Member { get; } = new GroupUserRole("Member", [
            new("CreateMessage"),
            new("ReadMessage"),
            new("EditMessage")]);

        public static GroupUserRole Admin { get; } = new GroupUserRole("Admin", [
            new("CreateMessage"),
            new("ReadMessage"),
            new("EditMessage"),
            new("AddMember"),
            new("RemoveMember")]);

        public string Value { get; }

        public List<GroupUserPermission> Permissions { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

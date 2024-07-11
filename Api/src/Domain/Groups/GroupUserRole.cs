using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserRole : Entity
    {
        private GroupUserRole(int id, string value)
        {
            Id = id;
            Value = value;
        }

        private GroupUserRole()
        {

        }

        public static GroupUserRole Admin { get; } = new GroupUserRole(1, "Admin");

        public static GroupUserRole Member { get; } = new GroupUserRole(2, "Member");

        public int Id { get; }

        public string Value { get; }

        public List<GroupUserPermission> Permissions { get; } = [];
    }
}

using Domain.SeedWork;

namespace Domain.Groups
{
    public class GroupUserRole : Entity
    {
        private GroupUserRole(string value)
        {
            Value = value;
        }

        private GroupUserRole()
        {

        }

        public static GroupUserRole Admin { get; } = new GroupUserRole("Admin");

        public static GroupUserRole Member { get; } = new GroupUserRole("Member");

        public int Id { get; }

        public List<GroupUser> Users { get; }

        public string Value { get; }

        public List<GroupUserPermission> Permissions { get; } = [];
    }
}

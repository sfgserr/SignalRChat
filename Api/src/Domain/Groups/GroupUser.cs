using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups
{
    public class GroupUser : Entity
    {
        private GroupUser(UserId userId, GroupId groupId, string roleValue, DateTime joinedDate)
        {
            UserId = userId;
            GroupId = groupId;
            RoleValue = roleValue;
            JoinedDate = joinedDate;
        }

        private GroupUser()
        {

        }

        public UserId UserId { get; }

        public GroupId GroupId { get; }

        public DateTime JoinedDate { get; }

        public string RoleValue { get; }

        internal static GroupUser Create(UserId userId, GroupId groupId, string role)
        {
            return new GroupUser(userId, groupId, role, DateTime.Now);
        }
    }
}

using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups
{
    public class GroupUser : Entity
    {
        private GroupUser(UserId userId, GroupId groupId, GroupUserRole role, DateTime joinedDate)
        {
            UserId = userId;
            GroupId = groupId;
            Role = role;
            JoinedDate = joinedDate;
        }

        private GroupUser()
        {

        }

        public UserId UserId { get; }

        public GroupId GroupId { get; }

        public DateTime JoinedDate { get; }

        public GroupUserRole Role { get; }

        internal static GroupUser Create(UserId userId, GroupId groupId, GroupUserRole role)
        {
            return new GroupUser(userId, groupId, role, DateTime.Now);
        }
    }
}

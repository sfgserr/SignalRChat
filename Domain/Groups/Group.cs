using Domain.Groups.Events;
using Domain.Groups.Rules;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups
{
    public class Group : Entity
    {
        private readonly List<GroupUser> _users;

        //for EF
        private Group()
        {
            
        }

        private Group(GroupId id, UserId adminId, string name)
        {
            Id = id;
            Name = name;

            _users = [GroupUser.Create(adminId, id, GroupUserRole.Admin)];

            AddDomainEvent(new GroupCreatedDomainEvent(id, adminId));
        }

        public GroupId Id { get; }

        public string Name { get; private set; }

        public IReadOnlyCollection<GroupUser> Users  => _users.AsReadOnly();

        internal static Group Create(UserId adminId, string name)
        {
            return new Group(new GroupId(Guid.NewGuid()), adminId, name);
        }

        public void AddUser(UserId userId, UserId settingUserId)
        {
            CheckRule(new UserCanOnlyBeAddedOnceRule(userId, _users));
            CheckRule(new OnlyAdminCanAddUserToGroupRule(_users, settingUserId));

            _users.Add(GroupUser.Create(userId, Id, GroupUserRole.Member));

            AddDomainEvent(new NewUserAddedToGroupDomainEvent(Id, userId));
        }
    }
}

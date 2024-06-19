using Domain.Groups.Events;
using Domain.Groups.Rules;
using Domain.Messages;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Groups
{
    public class Group : Entity, IAggregateRoot
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

        public static Group Create(UserId adminId, string name)
        {
            return new Group(new GroupId(Guid.NewGuid()), adminId, name);
        }

        public void AddUser(UserId userId, UserId addingUserId)
        {
            CheckRule(new UserCanOnlyBeAddedOnceRule(userId, _users));
            CheckRule(new OnlyAdminCanChangeGroupRule(_users, addingUserId));

            _users.Add(GroupUser.Create(userId, Id, GroupUserRole.Member));

            AddDomainEvent(new NewUserAddedToGroupDomainEvent(Id, userId));
        }

        public void RemoveUser(UserId userId, UserId removingUserId)
        {
            CheckRule(new OnlyAdminCanChangeGroupRule(_users, removingUserId));
            CheckRule(new UserCanBeRemovedIfHeIsMemberOfGroupRule(userId, _users));

            GroupUser userToRemove = _users.SingleOrDefault(u => u.UserId == userId)!;

            _users.Remove(userToRemove);
        }

        public Message CreateMessage(UserId senderId, string body, MessageType type)
        {
            return Message.CreateMessage(senderId, this, body, type);
        }

        public void ChangeGroupName(string name, UserId changingUserId)
        {
            CheckRule(new OnlyAdminCanChangeGroupRule(_users, changingUserId));
            CheckRule(new NameMustBeProvidedRule(name));

            Name = name;
        }
    }
}

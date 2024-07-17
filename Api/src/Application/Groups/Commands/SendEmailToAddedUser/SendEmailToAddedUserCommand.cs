using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.SendEmailToAddedUser
{
    public class SendEmailToAddedUserCommand(Guid id, UserId addedUserId, GroupId groupId) : InternalCommandBase(id)
    {
        internal UserId AddedUserId { get; } = addedUserId;

        internal GroupId GroupId { get; } = groupId;
    }
}

using Application.Cqrs.Commands;
using Domain.Users;

namespace Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommand(Guid id, UserId proposingUserId, UserId proposedUserId) : InternalCommandBase(id)
    {
        public UserId ProposingUserId { get; } = proposingUserId;

        public UserId ProposedUserId { get; } = proposedUserId;
    }
}

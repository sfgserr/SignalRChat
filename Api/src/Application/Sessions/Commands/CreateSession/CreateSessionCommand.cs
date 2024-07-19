using Application.Cqrs.Commands;
using Domain.Users;

namespace Application.Sessions.Commands.CreateSession
{
    public class CreateSessionCommand(Guid id, UserId proposingUserId, UserId proposedUserId) : InternalCommandBase(id)
    {
        internal UserId ProposingUserId { get; } = proposingUserId;

        internal UserId ProposedUserId { get; } = proposedUserId;
    }
}

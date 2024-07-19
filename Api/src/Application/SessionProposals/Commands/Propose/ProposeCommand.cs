using Application.Cqrs.Commands;

namespace Application.SessionProposals.Commands.Propose
{
    public class ProposeCommand(Guid groupId, Guid toUserId) : ICommand
    {
        public Guid GroupId { get; } = groupId;

        public Guid ToUserId { get; } = toUserId;
    }
}

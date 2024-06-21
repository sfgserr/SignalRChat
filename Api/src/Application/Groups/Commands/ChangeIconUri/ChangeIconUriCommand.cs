using Application.Cqrs.Commands;

namespace Application.Groups.Commands.ChangeIconUri
{
    public class ChangeIconUriCommand(Guid groupId, string iconUri) : ICommand
    {
        public Guid GroupId { get; } = groupId;

        public string IconUri { get; } = iconUri;
    }
}

using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.ChangeIconUri
{
    public sealed class ChangeIconUriCommandHandler(IGroupRepository groupRepository, IUserContext userContext) :
        ICommandHandler<ChangeIconUriCommand>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(ChangeIconUriCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.ChangeIconUri(command.IconUri, _userContext.Id);
        }
    }
}

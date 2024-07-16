using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.ChangeIconUri
{
    internal class ChangeIconUriCommandHandler : ICommandHandler<ChangeIconUriCommand>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserContext _userContext;

        internal ChangeIconUriCommandHandler(IGroupRepository groupRepository, IUserContext userContext)
        {
            _groupRepository = groupRepository;
            _userContext = userContext;
        }

        public async Task Handle(ChangeIconUriCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.ChangeIconUri(command.IconUri, _userContext.Id);
        }
    }
}

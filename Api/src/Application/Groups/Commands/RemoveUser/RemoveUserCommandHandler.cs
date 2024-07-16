using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.RemoveUser
{
    internal class RemoveUserCommandHandler : ICommandHandler<RemoveUserCommand>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserContext _userContext;

        internal RemoveUserCommandHandler(IGroupRepository groupRepository, IUserContext userContext)
        {
            _groupRepository = groupRepository;
            _userContext = userContext;
        }

        public async Task Handle(RemoveUserCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.RemoveUser(new UserId(command.UserId), _userContext.Id);
        }
    }
}

using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.AddUser
{
    internal class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly IUserContext _userContext;
        private readonly IGroupRepository _groupRepository;

        internal AddUserCommandHandler(IUserContext userContext, IGroupRepository groupRepository)
        {
            _userContext = userContext;
            _groupRepository = groupRepository;
        }

        public async Task Handle(AddUserCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.AddUser(new UserId(command.UserId), _userContext.Id);
        }
    }
}

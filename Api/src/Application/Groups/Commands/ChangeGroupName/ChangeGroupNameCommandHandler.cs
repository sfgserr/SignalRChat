using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.ChangeGroupName
{
    internal class ChangeGroupNameCommandHandler : ICommandHandler<ChangeGroupNameCommand>
    {
        private readonly IGroupRepository _repository;
        private readonly IUserContext _userContext;

        internal ChangeGroupNameCommandHandler(IGroupRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task Handle(ChangeGroupNameCommand command)
        {
            Group group = await _repository.Get(new GroupId(command.GroupId));

            group.ChangeGroupName(command.Name, _userContext.Id);
        }
    }
}

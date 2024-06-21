using Application.Contracts;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.ChangeGroupName
{
    public sealed class ChangeGroupNameCommandHandler(IGroupRepository repository, IUserContext userContext) : 
        IChangeGroupNameCommandHandler
    {
        private readonly IGroupRepository _repository = repository;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(ChangeGroupNameCommand command)
        {
            Group group = await _repository.Get(new GroupId(command.GroupId));

            group.ChangeGroupName(command.Name, _userContext.Id);
        }
    }
}

using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.RemoveUser
{
    internal sealed class RemoveUserCommandHandler(IGroupRepository groupRepository, IUserContext userContext, 
        IUnitOfWork unitOfWork) : ICommandHandler<RemoveUserCommand>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUserContext _userContext = userContext;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(RemoveUserCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.RemoveUser(new UserId(command.UserId), _userContext.Id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

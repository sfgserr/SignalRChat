using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.RemoveUser
{
    internal sealed class RemoveUserCommandHandler(IGroupRepository groupRepository, IUserService userService, 
        IUnitOfWork unitOfWork) : ICommandHandler<RemoveUserCommand>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUserService _userService = userService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(RemoveUserCommand command)
        {
            Guid adminId = _userService.GetUserId();

            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.RemoveUser(new UserId(command.UserId), new UserId(adminId));

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

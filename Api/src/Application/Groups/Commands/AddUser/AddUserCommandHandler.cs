using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.AddUser
{
    internal sealed class AddUserCommandHandler(IUserService userService, IGroupRepository groupRepository, 
        IUnitOfWork unitOfWork) :ICommandHandler<AddUserCommand>
    {
        private readonly IUserService _userService = userService;
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(AddUserCommand command)
        {
            Guid userId = _userService.GetUserId();

            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.AddUser(new UserId(command.UserId), new UserId(userId));

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

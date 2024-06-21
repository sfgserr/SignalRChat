using Application.Contracts;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.AddUser
{
    public sealed class AddUserCommandHandler(IUserContext userContext, IGroupRepository groupRepository, 
        IUnitOfWork unitOfWork) : IAddUserCommandHandler
    {
        private readonly IUserContext _userContext = userContext;
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(AddUserCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.AddUser(new UserId(command.UserId), _userContext.Id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

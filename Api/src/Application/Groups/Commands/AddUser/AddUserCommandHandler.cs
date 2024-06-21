using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.AddUser
{
    internal sealed class AddUserCommandHandler(IUserContext userContext, IGroupRepository groupRepository, 
        IUnitOfWork unitOfWork) :ICommandHandler<AddUserCommand>
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

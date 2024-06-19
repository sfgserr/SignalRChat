using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands
{
    public sealed class CreateGroupCommandHandler(IGroupRepository groupRepository, IUnitOfWork unitOfWork) : 
        ICommandHandler<CreateGroupCommand>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateGroupCommand command)
        {
            await _groupRepository.Add(Group.Create(new UserId(command.UserId), command.Name));

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

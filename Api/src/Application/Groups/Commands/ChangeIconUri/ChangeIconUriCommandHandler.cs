using Application.Contracts;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.ChangeIconUri
{
    public sealed class ChangeIconUriCommandHandler(IGroupRepository groupRepository, IUserContext userContext, 
        IUnitOfWork unitOfWork) : IChangeIconUriCommandHandler
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUserContext _userContext = userContext;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(ChangeIconUriCommand command)
        {
            Group group = await _groupRepository.Get(new GroupId(command.GroupId));

            group.ChangeIconUri(command.IconUri, _userContext.Id);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

﻿using Application.Contracts;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.RemoveUser
{
    public sealed class RemoveUserCommandHandler(IGroupRepository groupRepository, IUserContext userContext, 
        IUnitOfWork unitOfWork) : IRemoveUserCommandHandler
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

﻿using Application.Contracts;
using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.CreateGroup
{
    internal sealed class CreateGroupCommandHandler(IGroupRepository groupRepository, IUserContext userContext, 
        IUnitOfWork unitOfWork) : ICommandHandler<CreateGroupCommand>
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IUserContext _userContext = userContext;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(CreateGroupCommand command)
        {
            await _groupRepository.Add(Group.Create(_userContext.Id, command.Name));

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

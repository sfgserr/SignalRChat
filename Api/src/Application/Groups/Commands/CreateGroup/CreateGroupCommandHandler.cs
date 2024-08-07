﻿using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.Users;

namespace Application.Groups.Commands.CreateGroup
{
    internal class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserContext _userContext;

        internal CreateGroupCommandHandler(IGroupRepository groupRepository, IUserContext userContext)
        {
            _groupRepository = groupRepository;
            _userContext = userContext;
        }

        public async Task Handle(CreateGroupCommand command)
        {
            await _groupRepository.Add(Group.Create(_userContext.Id, command.Name, command.IconUri));
        }
    }
}

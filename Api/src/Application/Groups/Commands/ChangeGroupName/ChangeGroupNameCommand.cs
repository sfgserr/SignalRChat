﻿using Application.Cqrs.Commands;

namespace Application.Groups.Commands.ChangeGroupName
{
    public class ChangeGroupNameCommand(Guid groupId, string name) : ICommand
    {
        public Guid GroupId { get; } = groupId;

        public string Name { get; } = name;
    }
}

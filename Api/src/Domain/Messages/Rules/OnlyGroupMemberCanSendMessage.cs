﻿using Domain.Groups;
using Domain.SeedWork;
using Domain.Users;

namespace Domain.Messages.Rules
{
    public class OnlyGroupMemberCanSendMessage(Group group, UserId userId) : IBusinessRule
    {
        private readonly Group _group = group;
        private readonly UserId _userId = userId;

        public bool IsBroken => !_group.Users.Any(u => u.UserId.Equals(_userId));

        public string Message => "User is not member of group";
    }
}

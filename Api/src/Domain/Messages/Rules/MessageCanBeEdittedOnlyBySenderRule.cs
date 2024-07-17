using Domain.SeedWork;
using Domain.Users;

namespace Domain.Messages.Rules
{
    public class MessageCanBeEdittedOnlyBySenderRule(Message message, UserId userId) : IBusinessRule
    {
        private readonly Message _message = message;
        private readonly UserId _userId = userId;

        public bool IsBroken => !_message.SenderId.Equals(_userId);

        public string Message => "Only Sender can edit message";
    }
}

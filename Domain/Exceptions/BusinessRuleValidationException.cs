using Domain.SeedWork;

namespace Domain.Exceptions
{
    public class BusinessRuleValidationException(IBusinessRule brokenRule) : Exception
    {
        private readonly IBusinessRule _brokenRule = brokenRule;

        public override string Message => _brokenRule.Message;
    }
}

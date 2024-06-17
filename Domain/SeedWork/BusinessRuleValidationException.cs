
namespace Domain.SeedWork
{
    public class BusinessRuleValidationException : Exception
    {
        private readonly IBusinessRule _brokenRule;

        public BusinessRuleValidationException(IBusinessRule brokenRule)
        {
            _brokenRule = brokenRule;
        }

        public override string Message => _brokenRule.Message;
    }
}

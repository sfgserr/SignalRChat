using Domain.SeedWork;

namespace Domain.Groups.Rules
{
    public class NameMustBeProvidedRule(string name) : IBusinessRule
    {
        private readonly string _name = name;

        public bool IsBroken => string.IsNullOrEmpty(_name);

        public string Message => "Name must be provided";
    }
}

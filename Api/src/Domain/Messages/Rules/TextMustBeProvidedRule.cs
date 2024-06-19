using Domain.SeedWork;

namespace Domain.Messages.Rules
{
    public class TextMustBeProvidedRule(string text) : IBusinessRule
    {
        private readonly string _text = text;

        public bool IsBroken => string.IsNullOrEmpty(_text);

        public string Message => "Text must be provided";
    }
}

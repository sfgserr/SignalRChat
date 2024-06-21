using Domain.SeedWork;

namespace Domain.Groups.Rules
{
    public class IconUriMustBeProvidedRule(string iconUri) : IBusinessRule
    {
        private readonly string _iconUri = iconUri;

        public bool IsBroken => string.IsNullOrEmpty(_iconUri);

        public string Message => "Icon uri can't be empty";
    }
}

using Domain.SeedWork;

namespace Domain.SessionProposals.Rules
{
    public class CannotAcceptMoreThanOnceRule(DateTime? acceptedDate) : IBusinessRule
    {
        private readonly DateTime? _acceptedDate = acceptedDate;

        public bool IsBroken => _acceptedDate is not null;

        public string Message => "Proposal already accepted";
    }
}

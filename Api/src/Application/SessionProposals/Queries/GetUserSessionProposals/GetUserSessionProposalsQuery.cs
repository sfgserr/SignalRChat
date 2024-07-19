using Application.Cqrs.Queries;

namespace Application.SessionProposals.Queries.GetUserSessionProposals
{
    public class GetUserSessionProposalsQuery : IQuery<IList<SessionProposalDto>>
    {
    }
}

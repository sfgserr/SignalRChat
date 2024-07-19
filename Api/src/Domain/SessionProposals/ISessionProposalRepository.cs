using Domain.SeedWork;
using Domain.Users;

namespace Domain.SessionProposals
{
    public interface ISessionProposalRepository : IRepository<SessionProposal>
    {
        Task<SessionProposal> Get(SessionProposalId id);

        Task<IList<SessionProposal>> Get(UserId userId);
    }
}

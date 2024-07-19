using Domain.SessionProposals;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Domain.SessionProposals
{
    internal class SessionProposalRepository : ISessionProposalRepository
    {
        private readonly ApplicationContext _applicationContext;

        internal SessionProposalRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(SessionProposal entity)
        {
            await _applicationContext.SessionProposals.AddAsync(entity);    
        }

        public async Task<SessionProposal> Get(SessionProposalId id)
        {
            return await _applicationContext.SessionProposals.FirstOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task<IList<SessionProposal>> Get(UserId userId)
        {
            return await _applicationContext.SessionProposals.Where(s => s.ProposedUserId == userId).ToListAsync();
        }

        public async Task<List<SessionProposal>> GetAll()
        {
            return await _applicationContext.SessionProposals.ToListAsync();
        }
    }
}

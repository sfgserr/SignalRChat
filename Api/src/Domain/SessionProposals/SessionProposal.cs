using Domain.Groups;
using Domain.SeedWork;
using Domain.SessionProposals.Events;
using Domain.SessionProposals.Rules;
using Domain.Users;

namespace Domain.SessionProposals
{
    public class SessionProposal : Entity, IAggregateRoot
    {
        private SessionProposal()
        {

        }

        private SessionProposal(
            SessionProposalId id, 
            UserId proposingUserId, 
            UserId proposedUserId,
            List<GroupUser> users, 
            ISessionsCounter counter)
        {
            CheckRule(new UserCannotProposeToHimselfRule(proposingUserId, proposedUserId));
            CheckRule(new UsersMustBeInOneGroupRule(users, proposingUserId, proposedUserId));
            CheckRule(new UsersCannotHaveCurrentSessionsRule(counter, proposingUserId, proposedUserId));

            Id = id;
            ProposingUserId = proposingUserId;
            ProposedUserId = proposedUserId;
            ProposedDate = DateTime.Now;

            AddDomainEvent(new SessionProposalCreatedDomainEvent(id));
        }

        internal static SessionProposal Create(
            UserId proposingUserId, 
            UserId proposedUserId, 
            List<GroupUser> users, 
            ISessionsCounter counter)
        {
            return new(new(Guid.NewGuid()), proposingUserId, proposedUserId, users, counter);
        }

        public SessionProposalId Id { get; }

        public UserId ProposingUserId { get; }

        public UserId ProposedUserId { get; }

        public DateTime ProposedDate { get; }

        public DateTime? AcceptedDate { get; private set; }

        public void AcceptProposal(UserId acceptingUserId)
        {
            CheckRule(new AcceptingUserMustBeProposedRule(acceptingUserId, ProposedUserId));
            CheckRule(new CannotAcceptMoreThanOnceRule(AcceptedDate));

            AcceptedDate = DateTime.Now;

            AddDomainEvent(new SessionProposalAcceptedDomainEvent(ProposingUserId, ProposedUserId));
        }
    }
}

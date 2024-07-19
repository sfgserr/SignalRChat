using Application.Cqrs.Commands;
using Domain.Groups;
using Domain.SessionProposals;
using Domain.Users;

namespace Application.SessionProposals.Commands.Propose
{
    internal class ProposeCommandHandler : ICommandHandler<ProposeCommand>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserContext _userContext;
        private readonly ISessionsCounter _counter;
        private readonly ISessionProposalRepository _sessionProposalRepository;

        internal ProposeCommandHandler(
            IGroupRepository groupRepository, 
            IUserContext userContext, 
            ISessionsCounter counter,
            ISessionProposalRepository sessionProposalRepository)
        {
            _groupRepository = groupRepository;
            _userContext = userContext;
            _counter = counter;
            _sessionProposalRepository = sessionProposalRepository;
        }

        public async Task Handle(ProposeCommand command)
        {
            Group group = await _groupRepository.Get(new(command.GroupId));

            SessionProposal proposal = group.Propose(_userContext.Id, new(command.ToUserId), _counter);

            await _sessionProposalRepository.Add(proposal);
        }
    }
}

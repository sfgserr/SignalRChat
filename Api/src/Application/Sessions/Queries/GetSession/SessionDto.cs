using Domain.Sessions;

namespace Application.Sessions.Queries.GetSession
{
    public class SessionDto(Session session)
    {
        public Guid SessionId { get; } = session.SessionId.Value;

        public Guid CrossUserId { get; } = session.CrossUserId.Value;

        public Guid NoughtUserId { get; } = session.NoughtUserId.Value;

        public bool IsCrossTurn { get; } = session.IsCrossTurn;

        public IReadOnlyCollection<Mark> Marks { get; } = session.Marks;
    }
}

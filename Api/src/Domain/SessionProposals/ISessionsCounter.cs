using Domain.Users;

namespace Domain.SessionProposals
{
    public interface ISessionsCounter
    {
        int CountUserSessions(UserId userID);
    }
}

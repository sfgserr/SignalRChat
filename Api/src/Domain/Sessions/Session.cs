using Domain.SeedWork;
using Domain.Sessions.Rules;
using Domain.Users;

namespace Domain.Sessions
{
    public class Session : Entity, IAggregateRoot
    {
        private readonly Mark[] _marks = new Mark[9];
        
        private Session()
        {

        }

        private Session(SessionId sessionId, UserId crossUserId, UserId noughtUserId)
        {
            SessionId = sessionId;
            CrossUserId = crossUserId;
            NoughtUserId = noughtUserId;
        }

        internal static Session CreateSession(UserId crossUserId, UserId noughUserId) =>
            new(new(Guid.NewGuid()), crossUserId, noughUserId);

        public SessionId SessionId { get; }

        public UserId CrossUserId { get; }

        public UserId NoughtUserId { get; }

        public UserId? WonUserId { get; private set; }

        public IReadOnlyCollection<Mark> Marks => _marks.AsReadOnly();

        public void PlaceMark(Mark mark, int index, UserId placingUser)
        {
            UserId userId = mark.Value == 'X' ? CrossUserId : NoughtUserId;

            CheckRule(new OnlyCertainUserCanPlaceCertainMarkRule(userId, placingUser));
            CheckRule(new CanPlaceMarkOnlyInUntakenCellRule(_marks, index));

            _marks[index] = mark;

            CheckWin(index, mark, placingUser);
        }

        private void CheckWin(int index, Mark mark, UserId placingUserId) 
        {
            int rowIndex = ((index+4)/3)-1;
            int columnIndex = index-(rowIndex)*3;

            int rowBeginningColumnIndex = (rowIndex - 1) * 3;

            int count = 0;

            for (int i = rowBeginningColumnIndex; i < rowBeginningColumnIndex+3; i++)
            {
                bool isWon = CountMarks(i, mark, placingUserId, ref count);

                if (isWon)
                    return;
            }

            for (int i = columnIndex; i < columnIndex+6; i += 3)
            {
                bool isWon = CountMarks(i, mark, placingUserId, ref count);

                if (isWon)
                    return;
            }
        }

        private bool CountMarks(int index, Mark mark, UserId placingUserId, ref int count)
        {
            if (_marks[index].Equals(mark))
            {
                count++;
            }
            else
            {
                count = 0;
                return false;
            }

            if (count == 3)
            {
                WonUserId = placingUserId;

                return true;
            }

            return false;
        }
    }
}

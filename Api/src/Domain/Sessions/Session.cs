using Domain.SeedWork;
using Domain.Sessions.Events;
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

        public static Session CreateSession(UserId crossUserId, UserId noughUserId) =>
            new(new(Guid.NewGuid()), crossUserId, noughUserId);

        public SessionId SessionId { get; }

        public UserId CrossUserId { get; }

        public UserId NoughtUserId { get; }

        public UserId? WinnerUserId { get; private set; }

        public bool IsDraw { get; private set; } = false;

        public bool IsCrossTurn { get; private set; } = true;

        public IReadOnlyCollection<Mark> Marks => _marks.AsReadOnly();

        public void PlaceMark(Mark mark, int index, UserId placingUser)
        {
            UserId userId = mark.Value == 'X' ? CrossUserId : NoughtUserId;

            CheckRule(new CannotPlaceMarkWhenSessionIsEndedRule(WinnerUserId, IsDraw));
            CheckRule(new OnlyCertainUserCanPlaceCertainMarkRule(userId, placingUser));
            CheckRule(new CanPlaceMarkOnlyInUntakenCellRule(_marks, index));
            CheckRule(new CannotPlaceMarkWhenItIsNotTurnRule(IsCrossTurn, mark));

            _marks[index] = mark;

            IsCrossTurn = !IsCrossTurn;

            AddDomainEvent(new MarkPlacedDomainEvent(index, mark, placingUser));
        }

        public void CheckWin(int index, Mark mark, UserId placingUserId)
        {
            int rowIndex = index / 3;
            int columnIndex = index % 3;

            bool rowWin = CheckLine(rowIndex * 3, 1, mark, placingUserId);
            bool columnWin = CheckLine(columnIndex, 3, mark, placingUserId);

            bool diagonalWin = false;

            if (rowIndex == columnIndex)
            {
                diagonalWin = CheckLine(0, 4, mark, placingUserId);
            }

            if (rowIndex + columnIndex == 2)
            {
                diagonalWin |= CheckLine(2, 2, mark, placingUserId);
            }

            bool isWin = rowWin || columnWin || diagonalWin;

            if (isWin)
            {
                AddDomainEvent(new SessionIsEndedDomainEvent(placingUserId));
            }
            else if (_marks.All(m => m != null))
            {
                IsDraw = true;

                AddDomainEvent(new SessionIsEndedDomainEvent());
            }
        }

        private bool CheckLine(int startIndex, int step, Mark mark, UserId placingUserId)
        {
            int count = 0;

            for (int i = startIndex; i < 9; i += step)
            {
                if (!_marks[i].Equals(mark))
                {
                    return false;
                }

                count++;

                if (count == 3)
                {
                    WinnerUserId = placingUserId;
                    return true;
                }
            }

            return false;
        }
    }
}

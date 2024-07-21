using Domain.SeedWork;
using Domain.Sessions.Events;
using Domain.Sessions.Rules;
using Domain.Users;

namespace Domain.Sessions
{
    public class Session : Entity, IAggregateRoot
    {
        private readonly List<Mark> _marks = Enumerable.Repeat(Mark.DefaultValue, 9).ToList();
        
        private Session()
        {

        }

        private Session(SessionId sessionId, UserId crossUserId, UserId noughtUserId)
        {
            Id = sessionId;
            CrossUserId = crossUserId;
            NoughtUserId = noughtUserId;

            AddDomainEvent(new SessionCreatedDomainEvent(sessionId, crossUserId, noughtUserId));
        }

        public static Session CreateSession(UserId crossUserId, UserId noughUserId) =>
            new(new(Guid.NewGuid()), crossUserId, noughUserId);

        public SessionId Id { get; }

        public UserId CrossUserId { get; }

        public UserId NoughtUserId { get; }

        public UserId? WinnerUserId { get; private set; }

        public bool IsEnded { get; private set; } = false;

        public bool IsCrossTurn { get; private set; } = true;

        public int LastPlacedMarkIndex { get; private set; } = 0;

        public IReadOnlyCollection<Mark> Marks => _marks.AsReadOnly();

        public void PlaceMark(int index, UserId placingUserId)
        {
            CheckRule(new UserShouldBeInSessionToPlaceMark(placingUserId, CrossUserId, NoughtUserId));
            CheckRule(new CannotPlaceMarkWhenSessionIsEndedRule(IsEnded));
            CheckRule(new CannotPlaceMarkWhenItIsNotTurnRule(IsCrossTurn, placingUserId, CrossUserId));
            CheckRule(new CanPlaceMarkOnlyInUntakenCellRule(_marks, index));

            Mark mark = placingUserId.Equals(CrossUserId) ? Mark.Cross : Mark.Nought;

            _marks[index] = mark;

            LastPlacedMarkIndex = index;
            IsCrossTurn = !IsCrossTurn;

            AddDomainEvent(new MarkPlacedDomainEvent(
                Id, 
                placingUserId != CrossUserId ? CrossUserId : NoughtUserId,
                mark));
        }

        public void CheckWin()
        {
            int index = LastPlacedMarkIndex;
            Mark mark = _marks[index];
            UserId placedUserId = mark.Value == 'X' ? CrossUserId : NoughtUserId;

            int rowIndex = index / 3;
            int columnIndex = index % 3;

            bool rowWin = CheckLine(rowIndex * 3, 1, mark, placedUserId);
            bool columnWin = CheckLine(columnIndex, 3, mark, placedUserId);

            bool diagonalWin = false;

            if (rowIndex == columnIndex)
            {
                diagonalWin = CheckLine(0, 4, mark, placedUserId);
            }

            if (rowIndex + columnIndex == 2)
            {
                diagonalWin |= CheckLine(2, 2, mark, placedUserId);
            }

            bool isWin = rowWin || columnWin || diagonalWin;

            if (isWin || _marks.All(m => !m.Equals(Mark.DefaultValue)))
            {
                IsEnded = true;

                AddDomainEvent(new SessionEndedDomainEvent(CrossUserId, NoughtUserId, WinnerUserId));
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

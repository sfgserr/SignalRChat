using Domain.SeedWork;

namespace Domain.Sessions.Rules
{
    public class CannotPlaceMarkWhenItIsNotTurnRule(bool isCrossTurn, Mark mark) : IBusinessRule
    {
        private readonly bool _isCrossTurn = isCrossTurn;
        private readonly Mark _mark = mark;

        public bool IsBroken => _isCrossTurn ? !_mark.Equals(Mark.Cross) : !_mark.Equals(Mark.Nought);

        public string Message => "It's not your turn to place mark";
    }
}

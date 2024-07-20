using Domain.SeedWork;

namespace Domain.Sessions.Rules
{
    public class CanPlaceMarkOnlyInUntakenCellRule(Mark?[] marks, int index) : IBusinessRule
    {
        private readonly Mark?[] _marks = marks;
        private readonly int _index = index;

        public bool IsBroken => _marks[_index] != null;

        public string Message => "Cell is taken";
    }
}

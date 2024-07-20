using Domain.SeedWork;

namespace Domain.Sessions.Rules
{
    public class CanPlaceMarkOnlyInUntakenCellRule(List<Mark> marks, int index) : IBusinessRule
    {
        private readonly List<Mark> _marks = marks;
        private readonly int _index = index;

        public bool IsBroken => !_marks[_index].Equals(Mark.DefaultValue);

        public string Message => "Cell is taken";
    }
}

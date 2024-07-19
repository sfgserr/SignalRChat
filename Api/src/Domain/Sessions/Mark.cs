using Domain.SeedWork;

namespace Domain.Sessions
{
    public class Mark : ValueObject
    {
        private Mark(char value)
        {
            Value = value;
        }

        public static Mark Cross { get; } = new('X');

        public static Mark Nought { get; } = new('O');

        public char Value { get; }

        public static Mark? Parse(char value) =>
            Cross.Value == value ? Cross : Nought.Value == value ? Nought : null;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

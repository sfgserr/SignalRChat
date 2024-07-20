using Domain.SeedWork;

namespace Domain.Sessions
{
    public class Mark : ValueObject
    {
        private Mark(char value)
        {
            Value = value;
        }

        private Mark()
        {

        }

        public static Mark Cross { get; } = new('X');

        public static Mark Nought { get; } = new('O');

        public static Mark DefaultValue { get; } = new('*');

        public char Value { get; }

        public static Mark Parse(char value) =>
            Cross.Value == value ? Cross : Nought.Value == value ? Nought : DefaultValue;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

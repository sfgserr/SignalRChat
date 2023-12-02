
namespace Domain.ValueObjects
{
    public readonly struct MessageId : IEquatable<MessageId>
    {
        public Guid Id { get; }

        public bool Equals(MessageId other) => Id == other.Id;

        public override bool Equals(object? obj) =>
            obj is MessageId o && Equals(o);

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(MessageId left, MessageId right) => left.Equals(right);

        public static bool operator !=(MessageId left, MessageId right) => !(left == right);

        public override string ToString() => Id.ToString();
    }
}

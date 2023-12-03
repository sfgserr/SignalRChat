
namespace Domain.ValueObjects
{
    public readonly struct RoomId : IEquatable<RoomId>
    {
        public Guid Id { get; }

        public bool Equals(RoomId other) => Id == other.Id;

        public override bool Equals(object? obj) =>
            obj is RoomId o && Equals(o);

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(RoomId left, RoomId right) => left.Equals(right);

        public static bool operator !=(RoomId left, RoomId right) => !(left == right);

        public override string ToString() => Id.ToString();
    }
}

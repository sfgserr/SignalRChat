
namespace Infrastructure.InternalCommands
{
    public class InternalCommand(Guid id, string type, string data)
    {
        public Guid Id { get; } = id;

        public string Type { get; } = type;

        public string Data { get; } = data;

        public DateTime? ProcessedDate { get; set; }

        public string? Error { get; set; }
    }
}

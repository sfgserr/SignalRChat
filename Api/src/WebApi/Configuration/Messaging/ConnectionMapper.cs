using System.Collections.Concurrent;

namespace WebApi.Configuration.Messaging
{
    public class ConnectionMapper
    {
        private static readonly ConcurrentDictionary<Guid, List<string>> _ids = [];

        public static List<string>? GetConnections(Guid id)
        {
            _ids.TryGetValue(id, out var connections);

            return connections;
        }

        public static void AddConnection(Guid identityId, string connectionId)
        {
            _ids[identityId] = _ids[identityId] ?? [];

            _ids[identityId].Add(connectionId);
        }

        public static void RemoveConnection(Guid identityId, string connectionId)
        {
            _ids[identityId].Remove(connectionId);
        }
    }
}

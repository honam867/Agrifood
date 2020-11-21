using Microsoft.Extensions.Options;

namespace AspNetCore.Common.ConnectionString
{
    public class Connection : IConnection
    {
        private readonly ConnectionSettings _connectionSettings;
        public Connection(
            IOptions<ConnectionSettings> connectionSettings
            )
        {
            _connectionSettings = connectionSettings.Value;
        }

        public string GetConnectionString()
        {
            return _connectionSettings.DefaultConnection;
        }
    }
}

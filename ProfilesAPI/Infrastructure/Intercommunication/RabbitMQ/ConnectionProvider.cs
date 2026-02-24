using RabbitMQ.Client;

namespace Intercommunication.RabbitMQ;

public class ConnectionProvider : IDisposable, IConnectionProvider
{
    private readonly ConnectionFactory _connectionFactory;
    private IConnection _connection;

    public ConnectionProvider()
    {
        _connectionFactory = new ConnectionFactory
        {
            ClientProvidedName = "ProfilesAPI",
            HostName = "localhost",
        };
    }

    public async Task<IConnection> GetConnectionAsync()
    {
        if (_connection == null || !_connection.IsOpen)
        {
            _connection = await _connectionFactory.CreateConnectionAsync();
        }
        
        return _connection;
    }

    public void Dispose()
    {
        _connection?.CloseAsync().GetAwaiter().GetResult();
        _connection?.Dispose();
    }
}
using RabbitMQ.Client;

namespace RabbitMQ;

public interface IConnectionProvider
{
    Task<IConnection> GetConnectionAsync();
}

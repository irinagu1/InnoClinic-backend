using RabbitMQ.Client;

namespace Intercommunication.RabbitMQ;

public interface IConnectionProvider
{
    Task<IConnection> GetConnectionAsync();
}

using RabbitMQ.Client;

namespace Intercommunication.RabbitMQ;

public class ChannelProvider : IChannelProvider, IDisposable
{
    private readonly IConnectionProvider _connectionProvider;
    private IChannel _channel;

    public ChannelProvider(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<IChannel> GetChannelAsync()
    {
        if (_channel == null || !_channel.IsOpen)
        {
            var _connection = await _connectionProvider.GetConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
        }
        return _channel;
    }

    public void Dispose()
    {
        _channel?.CloseAsync().GetAwaiter().GetResult();
        _channel?.Dispose();
    }
}
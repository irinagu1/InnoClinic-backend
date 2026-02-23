using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Services.Interfaces;
using Shared.Messaging;

namespace Intercommunication.RabbitMQ;

public class RabbitMqBus : IEventBus, IDisposable
{
    private readonly RabbitMQSettings _settings;
    public RabbitMqBus(IOptions<RabbitMQSettings> options)
    {
        _settings = options.Value;    
    }

    public async Task PublishAsync<T>
        (T @event, string routingKey, CancellationToken ct = default) 
        where T : IntegrationEvent
    {
        var factory = new ConnectionFactory() { HostName = _settings.Host };
        using (var connection = await factory.CreateConnectionAsync())
        using (var channel = await connection.CreateChannelAsync())
        {
            await channel.QueueDeclareAsync(
                queue: routingKey,
                durable: true, 
                exclusive: false, 
                autoDelete: false, 
                arguments: null);
    
            string message = JsonSerializer.Serialize(@event);
            
            var body = Encoding.UTF8.GetBytes(message);
            
            await channel.BasicPublishAsync(    
                exchange: _settings.ExchangeName,
                routingKey: routingKey,
                mandatory: true, 
                basicProperties: new BasicProperties { Persistent = true }, 
                body: body);
       }
    }

    public void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        throw new NotImplementedException();
    }

    public void Unsubscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

}
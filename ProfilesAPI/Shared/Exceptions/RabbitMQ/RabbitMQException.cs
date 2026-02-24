namespace Shared.Exceptions.RabbitMQ;

public class RabbitMQException : Exception
{
    private readonly string _exType;

    public RabbitMQException(string exType, string message) 
        : base(message)
    {
        _exType = exType;    
    }
}
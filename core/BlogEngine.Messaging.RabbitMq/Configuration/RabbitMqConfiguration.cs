namespace BlogEngine.Messaging.RabbitMq.Configuration
{
    public sealed record RabbitMqConfiguration
    {
        public string Host { get; init; } = "127.0.0.1";
        public int Port { get; init; } = 5672;

        public string Username { get; init; } = "guest";
        public string Password { get; init; } = "guest";
    }
}
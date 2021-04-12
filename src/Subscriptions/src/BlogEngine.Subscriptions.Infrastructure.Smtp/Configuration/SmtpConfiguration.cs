namespace BlogEngine.Subscriptions.Infrastructure.Smtp.Configuration
{
    // TODO: Cover all settings
    public sealed record SmtpConfiguration
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
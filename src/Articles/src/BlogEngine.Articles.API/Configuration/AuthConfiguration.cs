namespace BlogEngine.Articles.API.Configuration
{
    public sealed record AuthConfiguration
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
namespace BlogEngine.Articles.API.Configuration
{
    public sealed record DatabaseConfiguration
    {
        public string ConnectionString { get; init; }
    }
}
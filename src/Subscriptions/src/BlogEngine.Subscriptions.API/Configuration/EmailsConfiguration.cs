namespace BlogEngine.Subscriptions.API.Configuration
{
    public sealed record EmailsConfiguration
    {
        public string NotificationsFrom { get; init; }
    }
}
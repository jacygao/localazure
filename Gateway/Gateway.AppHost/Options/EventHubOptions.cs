namespace Gateway.AppHost.Options
{
    public class EventHubOptions : BaseOptions
    {
        public const string Position = "EventHub";

        public string HubName { get; set; } = "testhub";
    }
}

namespace Gateway.AppHost.Options
{
    public class BaseOptions
    {
        public bool Enabled { get; set; } = true;

        public int HttpsPort { get; set; } = 0;
    }
}

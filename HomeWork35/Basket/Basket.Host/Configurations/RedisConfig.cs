namespace Basket.Host.Config
{
    public class RedisConfig
    {
        public string Host { get; set; } = null!;
        public TimeSpan CacheTimeout { get; set; }

    }
}

using StackExchange.Redis;

internal class Program
{
    private static readonly string redisConnectionString = "localhost:6379";
    private static ConnectionMultiplexer redis;
    private static IDatabase db;

    public static async Task Main(string[] args)
    {
        redis = ConnectionMultiplexer.Connect(redisConnectionString);
        db = redis.GetDatabase();

        // Create (Set) a key-value pair
        db.StringSet("mykey", "Hello, Azure Redis!");

        // Read (Get) the value of the key
        var value = db.StringGet("mykey");
        Console.WriteLine($"The value of 'mykey' is: {value}");

        // Update (Set) the value of the key
        db.StringSet("mykey", "Hello, updated Azure Redis!");

        // Read (Get) the updated value of the key
        var updatedValue = db.StringGet("mykey");
        Console.WriteLine($"The updated value of 'mykey' is: {updatedValue}");

        // Delete the key
        db.KeyDelete("mykey");

        // Try to read the deleted key
        var deletedValue = db.StringGet("mykey");
        if (string.IsNullOrEmpty(deletedValue))
        {
            Console.WriteLine("The key 'mykey' has been deleted.");
        }
        else
        {
            Console.WriteLine($"The value of 'mykey' is: {deletedValue}");
        }
    }
}
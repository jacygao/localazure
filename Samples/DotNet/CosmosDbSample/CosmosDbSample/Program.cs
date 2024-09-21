using Microsoft.Azure.Cosmos;

internal class Program
{
    private static readonly string endpoint = "https://localhost:8081";
    private static readonly string authKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

    private static readonly string databaseId = "samples";
    private static readonly string containerId = "container-samples";

    private static readonly string partitionKeyPath = "/activityId";

    public static async Task Main(string[] args)
    {
        CosmosClient client = new CosmosClient(endpoint, authKey);

        Database database = await client.CreateDatabaseIfNotExistsAsync(id: databaseId);

        Console.WriteLine($"A Database with id {databaseId} has been created.");
    }
}
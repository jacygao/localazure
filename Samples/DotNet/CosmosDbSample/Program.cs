using CosmosDb;
using Microsoft.Azure.Cosmos;

internal class Program
{
    private static readonly string endpoint = "https://localhost:8081";
    private static readonly string authKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

    private static readonly string databaseId = "samples";
    private static readonly string containerId = "container-samples";

    private static readonly string partitionKeyPath = "/category";

    public static async Task Main(string[] args)
    {
        CosmosClient client = new CosmosClient(endpoint, authKey);

        Database database = await client.CreateDatabaseIfNotExistsAsync(id: databaseId);

        Console.WriteLine($"A Database with id {databaseId} has been created.");

        Container container = await database.CreateContainerIfNotExistsAsync(
            id: containerId,
            partitionKeyPath: partitionKeyPath,
            throughput: 400
        );

        Console.WriteLine($"A Container with id {containerId} has been created.");

        Product item = new(
            id: "68719518388",
            category: "gear-surf-surfboards",
            name: "Sunnox Surfboard",
            quantity: 8,
            sale: true
        );

        try
        {
            // create an item
            _ = await container.CreateItemAsync<Product>(
                item: item,
                partitionKey: new PartitionKey("gear-surf-surfboards")
            );

            Console.WriteLine($"An item {item} has been created.");

            // replace an item
            _ = await container.ReplaceItemAsync<Product>(
                item: item,
                id: "68719518388",
                partitionKey: new PartitionKey("gear-surf-surfboards")
            );

            Console.WriteLine($"An item {item} has been replaced.");

            // upsert an item
            _ = await container.UpsertItemAsync<Product>(
                item: item,
                partitionKey: new PartitionKey("gear-surf-surfboards")
            );

            Console.WriteLine($"An item {item} has been upserted.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
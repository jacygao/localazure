using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using System.Net;

internal class Program
{
    private static readonly string databaseId = "samples";
    private static readonly string containerId = "container-samples";

    private static Database database = null;

    public static async Task Main(string[] args)
    {
        CosmosClient client = new CosmosClient(endpoint, authKey);

        database = await client.CreateDatabaseIfNotExistsAsync(databaseId);

    }

    // <CreateContainer>
    private static async Task<Container> CreateContainer()
    {
        // Set throughput to the minimum value of 400 RU/s
        ContainerResponse simpleContainer = await database.CreateContainerIfNotExistsAsync(
            id: containerId,
            partitionKeyPath: partitionKeyPath,
            throughput: 400);

        Console.WriteLine($"{Environment.NewLine}1.1. Created container :{simpleContainer.Container.Id}");
        return simpleContainer;
    }
    // </CreateContainer>
}
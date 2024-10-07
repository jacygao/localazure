# CosmosDb

Cosmos DB Local Simulation leverages the [Cosmos DB Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-nosql) pubished by Microsoft and runs it in a Docker Container.

## Start Cosmos DB Emulator in Docker

Under application root directory, run
```
docker compose up
```

Cosmos DB Emulator will be fully up once you see the following outputs:

```
...
cosmosdb   | Started 1/11 partitions
cosmosdb   | Started 2/11 partitions
cosmosdb   | Started 3/11 partitions
cosmosdb   | Started 4/11 partitions
cosmosdb   | Started 5/11 partitions
cosmosdb   | Started 6/11 partitions
cosmosdb   | Started 7/11 partitions
cosmosdb   | Started 8/11 partitions
cosmosdb   | Started 9/11 partitions
cosmosdb   | Started 10/11 partitions
cosmosdb   | Started 11/11 partitions
cosmosdb   | Started
```

## Configure SSL

You can import the emulator's TLS/SSL certificate to use the emulator with your preferred developer SDK without disabling TLS/SSL on the client.

### Windows

To import SSL, under the root directory, run
```
.\Scripts\CosmosDb\DownloadCert.ps1
```

## Configure local Cosmos DB Client

```
private static readonly string endpoint = "https://localhost:8081";

private static readonly string authKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

CosmosClient client = new CosmosClient(endpoint, authKey);

// Start your magic with the client
```

You can find more examples [here](../Samples/DotNet/CosmosDBSample/Program.cs)
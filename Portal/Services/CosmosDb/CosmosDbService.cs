using Microsoft.Azure.Cosmos;
using Portal.Entities;

namespace Portal.Services.CosmosDb
{
    public class CosmosDbService : ICosmosDbServiceProvider
    {
        private readonly CosmosDbOptions _options;
        private readonly CosmosClient _client;

        public CosmosDbService(CosmosDbOptions options) { 
            _options = options;
            _client = new CosmosClient(options.Endpoint, options.AuthKey);
        }

        public async Task<Database> CreateDatabaseAsync(string databaseId)
        {
            return await _client.CreateDatabaseIfNotExistsAsync(id: databaseId);
        }

        public async Task<Container> CreateContainerAsync(Database db, string containerId, string partitionKeyPath, int throughput)
        {
            return await db.CreateContainerIfNotExistsAsync(
                id: containerId,
                partitionKeyPath: partitionKeyPath,
                throughput: throughput
            );
        }

        public async Task CreateItemAsync(Product product, Container container)
        {

        }

        public async Task UpdateItem(Product product, Container container)
        {

        }

        public async Task DeleteItem()
        {

        }
    }
}

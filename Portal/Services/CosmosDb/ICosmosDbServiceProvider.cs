using Microsoft.Azure.Cosmos;
using Portal.Entities;

namespace Portal.Services.CosmosDb
{
    public interface ICosmosDbServiceProvider
    {
        public Task<CreateDatabaseResult> CreateDatabaseAsync(string databaseId);

        public Task<CreateContainerResult> CreateContainerAsync(Database db, string containerId, string partitionKeyPath, int throughput);

        public Task<CosmosDbResult> CreateItemAsync(Container container, Product product);

        public Task<CosmosDbResult> ReplaceItemAsync(Container container, Product product);

        public Task<CosmosDbResult> UpsertItemAsync(Container container, Product product);

        public Task<CosmosDbResult> DeleteItemAsync();

    }
}

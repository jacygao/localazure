using Microsoft.Azure.Cosmos;
using Portal.Entities;

namespace Portal.Services.CosmosDb
{
    public interface ICosmosDbServiceProvider
    {
        public Task<Database> CreateDatabaseAsync(string databaseId);

        public Task<Container> CreateContainerAsync(Database db, string containerId, string partitionKeyPath, int throughput);

        public Task CreateItemAsync(Product product, Container container);

        public Task ReplaceItem();

        public Task UpsertItem(Product product, Container container);

        public Task DeleteItem();

    }
}

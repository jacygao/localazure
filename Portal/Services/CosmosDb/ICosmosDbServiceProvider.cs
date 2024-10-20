using Microsoft.Azure.Cosmos;

namespace Portal.Services.CosmosDb
{
    public interface ICosmosDbServiceProvider
    {
        public Task<Database> CreateDatabaseAsync(string databaseId);

        public Task<Container> CreateContainerAsync(Database db, string containerId, string partitionKeyPath, int throughput);

        public Task CreateItemAsync();

        public Task ReplaceItem();

        public Task UpsertItem();
        
        public Task DeleteItem();

    }
}

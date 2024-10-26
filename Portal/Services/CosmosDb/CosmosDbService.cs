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
            try
            {
                return await _client.CreateDatabaseIfNotExistsAsync(id: databaseId);
            } catch (Exception ex) 
            {
                throw new CosmosDbException($"Failed to create database with id {databaseId}", Operation.CreateDatabase, ex);    
            }
        }

        public async Task<Container> CreateContainerAsync(Database db, string containerId, string partitionKeyPath, int throughput)
        {
            try
            {
                return await db.CreateContainerIfNotExistsAsync(
                    id: containerId,
                    partitionKeyPath: partitionKeyPath,
                    throughput: throughput
                );
            } catch(Exception ex)
            {
                throw new CosmosDbException($"Failed to create container with id {containerId}", Operation.CreateContainer, ex);
            }
        }

        public async Task CreateItemAsync(Product product, Container container)
        {

        }

        public async Task UpsertItem(Product product, Container container)
        {

        }

        public async Task ReplaceItem()
        {

        }

        public async Task DeleteItem()
        {

        }
    }
}

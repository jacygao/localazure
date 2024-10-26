using Microsoft.Azure.Cosmos;
using Portal.Entities;

namespace Portal.Services.CosmosDb
{
    public class CosmosDbService(CosmosDbOptions options) : ICosmosDbServiceProvider
    {
        private readonly CosmosDbOptions _options = options;
        private readonly CosmosClient _client = new(options.Endpoint, options.AuthKey);

        public async Task<CreateDatabaseResult> CreateDatabaseAsync(string databaseId)
        {
            try
            {
                var result = await _client.CreateDatabaseIfNotExistsAsync(id: databaseId);
                return new CreateDatabaseResult(true, result.Database);
            } catch (Exception)
            {
                return new CreateDatabaseResult(false, null);
            }
        }

        public async Task<CreateContainerResult> CreateContainerAsync(Database db, string containerId, string partitionKeyPath, int throughput)
        {
            try
            {
                var result = await db.CreateContainerIfNotExistsAsync(
                    id: containerId,
                    partitionKeyPath: partitionKeyPath,
                    throughput: throughput
                );
                return new CreateContainerResult(true, result);
            } catch(Exception)
            {
                return new CreateContainerResult(false, null);
            }
        }

        public async Task<CosmosDbResult> CreateItemAsync(Container container, Product product)
        {
            try
            {
                _ = await container.CreateItemAsync(
                    item: product,
                    partitionKey: new PartitionKey(product.category)
                );
                return new CosmosDbResult(true);
            } catch(Exception)
            {
                return new CosmosDbResult(false);
            }
        }

        public async Task<CosmosDbResult> UpsertItemAsync(Container container, Product product)
        {
            try
            {
                _ = await container.UpsertItemAsync(
                    item: product,
                    partitionKey: new PartitionKey(product.category)
                );
                return new CosmosDbResult(true);
            } catch(Exception)
            {
                return new CosmosDbResult(false);
            }
        }

        public async Task<CosmosDbResult> ReplaceItemAsync(Container container, Product product)
        {
            try
            {
                _ = await container.ReplaceItemAsync(
                    item: product,
                    id: product.id,
                    partitionKey: new PartitionKey(product.category)
                );
                return new CosmosDbResult(true);
            } catch(Exception)
            {
                return new CosmosDbResult(false);
            }
        }

        public async Task<CosmosDbResult> DeleteItemAsync()
        {
            return new CosmosDbResult(false);
        }
    }
}

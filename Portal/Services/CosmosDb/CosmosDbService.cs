using Microsoft.Azure.Cosmos;

namespace Portal.Services.CosmosDb
{
    public class CosmosDbService
    {
        private readonly CosmosDbOptions _options;
        private readonly CosmosClient _client;

        public CosmosDbService(CosmosDbOptions options) { 
            _options = options;
            _client = new CosmosClient(options.Endpoint, options.AuthKey);
        }

        public async Task CreateDatabaseAsync()
        {

        }

        public async Task CreateContainerAsync()
        {

        }

        public async Task CreateItemAsync()
        {

        }

        public async Task UpdateItem()
        {

        }

        public async Task DeleteItem()
        {

        }
    }
}

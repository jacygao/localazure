using Microsoft.Azure.Cosmos;

namespace Portal.Services.CosmosDb
{
    public class CosmosDbResult(bool success)
    {
        public bool Success { get; set; } = success;
    }

    public class CreateDatabaseResult(bool success, Database? database) : CosmosDbResult(success)
    {
        public Database? Database { get; } = database;
    }

    public class CreateContainerResult(bool success, Container? container) : CosmosDbResult(success)
    {
        public Container? Container { get; } = container;
    }
}

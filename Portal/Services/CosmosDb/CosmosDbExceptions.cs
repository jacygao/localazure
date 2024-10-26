using System.Runtime.Serialization;

namespace Portal.Services.CosmosDb
{
    public enum Operation
    {
        None,
        CreateDatabase,
        CreateContainer,
        CreateItem,
        ReplaceItem,
        UpsertItem,
        DeleteItem
    }

    [Serializable]
    public class CosmosDbException : Exception
    {
        public Operation CosmosDbOperation { get; }

        public CosmosDbException() { }

        public CosmosDbException(string message) : base(message) { }

        public CosmosDbException(string message, Operation operation, Exception? innerException = null)
        : base(message, innerException)
        {
            CosmosDbOperation = operation;
        }
    }
}

namespace CosmosDbSample
{
    public record Product(
        string id,
        string category,
        string name,
        int quantity,
        bool sale
    );
}

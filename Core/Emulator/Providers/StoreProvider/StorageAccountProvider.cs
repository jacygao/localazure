namespace Emulator.Providers.StoreProvider
{
    public class StorageAccountProvider<TItem> : IStoreProvider<TItem>
    {
        public StorageAccountProvider() { }

        // Implementation details for Azure Storage
        public void Save(string key, TItem? value)
        {
            // Code to save data to Azure Storage
            throw new NotImplementedException();
        }

        public TItem Load(string key)
        {
            // Code to load data from Azure Storage
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            // Code to delete data from Azure Storage
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

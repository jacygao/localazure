namespace KeyVaultEmulator.Providers.StoreProvider
{
    public class InMemoryStoreProvider : IStoreProvider
    {
        private readonly Dictionary<string, string> _store = new Dictionary<string, string>();

        public InMemoryStoreProvider() { }

        public void Save(string key, string value)
        {
            _store[key] = value;
        }

        public string Load(string key)
        {
            _store.TryGetValue(key, out var value);
            return value;
        }

        public void Delete(string key)
        {
            _store.Remove(key);
        }
    }

}

namespace Emulator.Providers.StoreProvider
{
    public interface IStoreProvider<TItem> : IDisposable
    {
        public void Save(string key, TItem? value);
        TItem Load(string key);
        void Delete(string key);
    }
}

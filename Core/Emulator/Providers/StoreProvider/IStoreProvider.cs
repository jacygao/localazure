namespace Emulator.Providers.StoreProvider
{
    public interface IStoreProvider
    {
        void Save(string key, string value);
        string Load(string key);
        void Delete(string key);
    }
}

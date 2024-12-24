using Microsoft.Extensions.Caching.Memory;

namespace Emulator.Providers.StoreProvider
{
    public class InMemoryStoreProvider<TItem> : IStoreProvider<TItem>
    {
        private readonly IMemoryCache _cache;

        public InMemoryStoreProvider(IMemoryCache cache) {
            this._cache = cache;
        }

        public void Save(string key, TItem? value)
        {
            if (value is null) 
            {
                throw new Exception($"cache value empty - key: {key}");
            }
            _cache.Set(key, value);
        }

        public TItem Load(string key)
        {
            if (_cache.TryGetValue(key, out TItem? value))
            {
                if (value is null)
                {
                    throw new Exception($"cache miss - key: {key}");
                }
                return value;
            }

            throw new Exception($"cache miss - key: {key}");
        }

        public void Delete(string key)
        {
            _cache.Remove(key);
        }

        public void Dispose()
        {   
            _cache.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}

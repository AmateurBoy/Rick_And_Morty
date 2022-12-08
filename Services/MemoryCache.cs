using Microsoft.Extensions.Caching.Memory;
using Rick_And_Morty.Convertor;
using Rick_And_Morty.Data;

namespace Rick_And_Morty.Services
{
    public class MemoryCache
    {
        private IMemoryCache _cache;       
        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void SetCache(string key, object value)
        {
            _cache.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
            });
        }

        public State GetCache(string key)
        {
            var value = (State?)_cache.Get(key);
            if (value != null)
            {
                return value;
            }
            return value;
        }
        public StatusCode? GetCacheStatusCode(string key)
        {
            var value = (StatusCode?)_cache.Get(key);
            if (value != null)
            {
                return value;
            }
            return value;
        }
    }
}

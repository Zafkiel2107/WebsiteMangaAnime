using System;
using System.Configuration;
using System.Runtime.Caching;

namespace WebsiteMangaAnime.Models.CacheControl
{
    public class Cache : ICache
    {
        private MemoryCache cache;
        private double cacheDuration;
        public Cache()
        {
            this.cache = MemoryCache.Default;
            this.cacheDuration = double.Parse(ConfigurationManager.AppSettings["CacheDuration"]);
        }
        public bool Add<TEntity>(TEntity item, Guid id) where TEntity : class
        {
            return cache.Add(id.ToString(), item, DateTime.Now.AddMinutes(cacheDuration));
        }
        public void Delete(Guid id)
        {
            if (cache.Contains(id.ToString()))
            {
                cache.Remove(id.ToString());
            }
        }
        public void Dispose()
        {
            cache.Dispose();
        }
        public TEntity GetElementById<TEntity>(Guid id) where TEntity : class
        {
            return cache.Get(id.ToString()) as TEntity;
        }
        public void Update<TEntity>(TEntity item, Guid id) where TEntity : class
        {
            cache.Set(id.ToString(), item, DateTime.Now.AddMinutes(cacheDuration));
        }
    }
}
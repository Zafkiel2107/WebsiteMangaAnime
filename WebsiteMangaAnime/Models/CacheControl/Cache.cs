using System;
using System.Configuration;
using System.Runtime.Caching;
using WebsiteMangaAnime.Models.BaseClasses;

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
        public bool Add<TEntity>(TEntity item) where TEntity : Entity
        {
            return cache.Add(item.Id, item, DateTime.Now.AddMinutes(cacheDuration));
        }
        public void Delete(string id)
        {
            if (cache.Contains(id))
            {
                cache.Remove(id);
            }
        }
        public void Dispose()
        {
            cache.Dispose();
        }
        public TEntity GetElementById<TEntity>(string id) where TEntity : Entity
        {
            return cache.Get(id) as TEntity;
        }

        public bool IsInCache(string id)
        {
            return cache.Contains(id);
        }

        public void Update<TEntity>(TEntity item) where TEntity : Entity
        {
            cache.Set(item.Id, item, DateTime.Now.AddMinutes(cacheDuration));
        }
    }
}
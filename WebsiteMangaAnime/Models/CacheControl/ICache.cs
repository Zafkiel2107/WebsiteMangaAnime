using System;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models.CacheControl
{
    internal interface ICache : IDisposable
    {
        TEntity GetElementById<TEntity>(string id) where TEntity : Entity;
        bool Add<TEntity>(TEntity item) where TEntity : Entity;
        void Update<TEntity>(TEntity item) where TEntity : Entity;
        void Delete(string id);
        bool IsInCache(string id);
    }
}

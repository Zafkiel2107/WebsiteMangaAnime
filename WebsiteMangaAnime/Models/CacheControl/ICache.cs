using System;

namespace WebsiteMangaAnime.Models.CacheControl
{
    internal interface ICache : IDisposable
    {
        TEntity GetElementById<TEntity>(Guid id) where TEntity : class;
        bool Add<TEntity>(TEntity item, Guid id) where TEntity : class;
        void Update<TEntity>(TEntity item, Guid id) where TEntity : class;
        void Delete(Guid id);
    }
}

using System;

namespace WebsiteMangaAnime.Models.CacheControl
{
    internal interface ICache<TEntity> : IDisposable
    {
        TEntity GetElementById(Guid id);
        bool Add(TEntity item, Guid id);
        void Update(TEntity item, Guid id);
        void Delete(Guid id);
    }
}

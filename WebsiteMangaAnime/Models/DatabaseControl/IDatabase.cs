using System;
using System.Collections.Generic;

namespace WebsiteMangaAnime.Models.DatabaseControl
{
    internal interface IDatabase<TEntity> : IDisposable
    {
        IEnumerable<TEntity> GetElements();
        TEntity GetElementById(Guid id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(Guid id);
    }
}

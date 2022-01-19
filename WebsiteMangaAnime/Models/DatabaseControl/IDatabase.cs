using System;
using System.Collections.Generic;

namespace WebsiteMangaAnime.Models.DatabaseControl
{
    internal interface IDatabase : IDisposable
    {
        IEnumerable<TEntity> GetElements<TEntity>() where TEntity : class;
        TEntity GetElementById<TEntity>(Guid id) where TEntity : class;
        void Create<TEntity>(TEntity item) where TEntity : class;
        void Update<TEntity>(TEntity item) where TEntity : class;
        void Delete<TEntity>(Guid id) where TEntity : class;
    }
}

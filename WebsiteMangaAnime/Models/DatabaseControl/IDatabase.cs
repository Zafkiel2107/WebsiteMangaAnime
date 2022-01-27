using System;
using System.Collections.Generic;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models.DatabaseControl
{
    public interface IDatabase : IDisposable
    {
        IEnumerable<TEntity> GetElements<TEntity>() where TEntity : Entity;
        TEntity GetElementById<TEntity>(string id) where TEntity : Entity;
        void Create<TEntity>(TEntity item) where TEntity : Entity;
        void Update<TEntity>(TEntity item) where TEntity : Entity;
        void Delete<TEntity>(string id) where TEntity : Entity;
    }
}

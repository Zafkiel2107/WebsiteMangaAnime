using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebsiteMangaAnime.Models.CacheControl;
using WebsiteMangaAnime.Models.Context;
using WebsiteMangaAnime.Models.DatabaseControl;
using WebsiteMangaAnime.Models.LogControl;

namespace WebsiteMangaAnime.Models.Storage
{
    public class Storage : IDatabase
    {
        private ICache cache;
        private AppDbContext db;
        public Storage()
        {
            this.cache = new Cache();
            this.db = new AppDbContext();
        }
        public async void Create<TEntity>(TEntity item) where TEntity : class
        {
            var entity = db.Set<TEntity>();
            entity.Add(item);
            await db.SaveChangesAsync();
        }
        public async void Delete<TEntity>(Guid id)
            where TEntity : class
        {
            var entity = db.Set<TEntity>();
            var item = entity.Find(id);
            if (item != null)
            {
                entity.Remove(item);
            }
            await db.SaveChangesAsync();
            cache.Delete(id);
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public TEntity GetElementById<TEntity>(Guid id)
            where TEntity : class
        {
            TEntity item = cache.GetElementById<TEntity>(id);
            if (item == null)
            {
                item = db.Set<TEntity>().Find(id);
            }
            return item;
        }
        public IEnumerable<TEntity> GetElements<TEntity>()
            where TEntity : class
        {
            return db.Set<TEntity>();
        }
        public async void Update<TEntity>(TEntity item)
            where TEntity : class
        {
            db.Entry<TEntity>(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
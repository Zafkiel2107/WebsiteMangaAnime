using System.Collections.Generic;
using System.Data.Entity;
using WebsiteMangaAnime.Models.BaseClasses;
using WebsiteMangaAnime.Models.CacheControl;
using WebsiteMangaAnime.Models.Context;
using WebsiteMangaAnime.Models.DatabaseControl;

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
        public async void Create<TEntity>(TEntity item) where TEntity : Entity
        {
            var entity = db.Set<TEntity>();
            entity.Add(item);
            int result = await db.SaveChangesAsync();
            if(result > 0)
            {
                cache.Add<TEntity>(item);
            }
        }
        public async void Delete<TEntity>(string id)
            where TEntity : Entity
        {
            var entity = db.Set<TEntity>();
            var item = entity.Find(id);
            if (item != null)
            {
                entity.Remove(item);
            }
            int result = await db.SaveChangesAsync();
            if (result > 0)
            {
                cache.Delete(id);
            }
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public TEntity GetElementById<TEntity>(string id)
            where TEntity : Entity
        {
            if(cache.IsInCache(id))
            {
                return cache.GetElementById<TEntity>(id);
            }
            else
            {
                return db.Set<TEntity>().Find(id);
            }
        }
        public IEnumerable<TEntity> GetElements<TEntity>()
            where TEntity : Entity
        {
            return db.Set<TEntity>();
        }
        public async void Update<TEntity>(TEntity item)
            where TEntity : Entity
        {
            db.Entry<TEntity>(item).State = EntityState.Modified;
            int result = await db.SaveChangesAsync();
            if (result > 0)
            {
                cache.Update<TEntity>(item);
            }
        }
    }
}
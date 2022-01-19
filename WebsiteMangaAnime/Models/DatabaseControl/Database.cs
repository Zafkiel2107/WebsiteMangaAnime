using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebsiteMangaAnime.Models.Context;

namespace WebsiteMangaAnime.Models.DatabaseControl
{
    public class Database : IDatabase
    {
        private AppDbContext db;
        public Database()
        {
            this.db = new AppDbContext();
        }
        public async void Create<TEntity>(TEntity item)
            where TEntity : class
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
                entity.Remove(item);
            await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public TEntity GetElementById<TEntity>(Guid id)
            where TEntity : class
        {
            return db.Set<TEntity>().Find(id);
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
using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebsiteMangaAnime.Models.BaseClasses;
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
            where TEntity : Entity
        {
            var entity = db.Set<TEntity>();
            entity.Add(item);
            await db.SaveChangesAsync();
        }
        public async void Delete<TEntity>(string id)
            where TEntity : Entity
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
        public TEntity GetElementById<TEntity>(string id)
            where TEntity : Entity
        {
            return db.Set<TEntity>().Find(id);
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
            await db.SaveChangesAsync();
        }
    }
}
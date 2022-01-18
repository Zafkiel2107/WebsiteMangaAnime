using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebsiteMangaAnime.Models.Context;

namespace WebsiteMangaAnime.Models.DatabaseControl
{
    public class Database<TEntity> : IDatabase<TEntity> where TEntity : class
    {
        private AppDbContext db;
        private DbSet<TEntity> entity;
        public Database()
        {
            this.db = new AppDbContext();
            this.entity = db.Set<TEntity>();
        }
        public async void Create(TEntity item)
        {
            entity.Add(item);
            await db.SaveChangesAsync();
        }
        public async void Delete(Guid id)
        {
            TEntity item = entity.Find(id);
            if (item != null)
                entity.Remove(item);
            await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            db.Dispose();
        }
        public TEntity GetElementById(Guid id)
        {
            return entity.Find(id);
        }
        public IEnumerable<TEntity> GetElements()
        {
            return entity;
        }
        public async void Update(TEntity item)
        {
            db.Entry<TEntity>(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
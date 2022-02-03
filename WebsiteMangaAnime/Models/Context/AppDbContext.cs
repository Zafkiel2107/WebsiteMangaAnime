using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebsiteMangaAnime.Models.BaseClasses;
using WebsiteMangaAnime.Models.LogControl;

namespace WebsiteMangaAnime.Models.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() : base("DefaultConnection")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterReview> CharacterReviews { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.Ignore<Product>();
            modelBuilder.Ignore<Review>();
            modelBuilder.Entity<Anime>().ToTable(nameof(Animes));
            modelBuilder.Entity<Manga>().ToTable(nameof(Mangas));
            base.OnModelCreating(modelBuilder);
        }
    }
}
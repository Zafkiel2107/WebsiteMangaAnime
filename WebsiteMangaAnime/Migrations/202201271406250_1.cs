namespace WebsiteMangaAnime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Director = c.String(nullable: false),
                        Studio = c.String(nullable: false),
                        Season = c.Byte(nullable: false),
                        Series = c.Short(nullable: false),
                        VideoLink = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Status = c.Byte(nullable: false),
                        AgeRating = c.Byte(nullable: false),
                        Rating = c.Double(nullable: false),
                        RecommendationsNumber = c.Int(nullable: false),
                        Year = c.Short(nullable: false),
                        Description = c.String(nullable: false),
                        ImageLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    GenreType = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.GenresProducts",
                c => new
                {
                    Anime_Id = c.String(nullable: true, maxLength: 128),
                    Manga_Id = c.String(nullable: true, maxLength: 128),
                    Genre_Id = c.String(nullable: false, maxLength: 128),
                })
                .ForeignKey("dbo.Animes", t => t.Anime_Id)
                .ForeignKey("dbo.Mangas", t => t.Manga_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id);

            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsRecommended = c.Boolean(nullable: false),
                        Rating = c.Byte(nullable: false),
                        Content = c.String(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Anime_Id = c.String(maxLength: 128),
                        Manga_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Animes", t => t.Anime_Id)
                .ForeignKey("dbo.Mangas", t => t.Manga_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Anime_Id)
                .Index(t => t.Manga_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Birthday = c.DateTime(nullable: false),
                        ImageLink = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.CharacterReviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Rating = c.Byte(nullable: false),
                        Content = c.String(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        Character_Id = c.String(nullable: false, maxLength: 128),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Character_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Gender = c.Byte(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Rating = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        ImageLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ExceptionLogs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ExceptionMessage = c.String(nullable: false),
                        ControllerName = c.String(nullable: false),
                        ActionName = c.String(nullable: false),
                        StackTrace = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mangas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Author = c.String(nullable: false),
                        Publisher = c.String(nullable: false),
                        Tom = c.Byte(nullable: false),
                        Chapter = c.Short(nullable: false),
                        MangaLink = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Status = c.Byte(nullable: false),
                        AgeRating = c.Byte(nullable: false),
                        Rating = c.Double(nullable: false),
                        RecommendationsNumber = c.Int(nullable: false),
                        Year = c.Short(nullable: false),
                        Description = c.String(nullable: false),
                        ImageLink = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductReviews", "Manga_Id", "dbo.Mangas");
            DropForeignKey("dbo.Genres", "Manga_Id", "dbo.Mangas");
            DropForeignKey("dbo.ProductReviews", "Anime_Id", "dbo.Animes");
            DropForeignKey("dbo.ProductReviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CharacterReviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CharacterReviews", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Genres", "Anime_Id", "dbo.Animes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.CharacterReviews", new[] { "User_Id" });
            DropIndex("dbo.CharacterReviews", new[] { "Character_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ProductReviews", new[] { "Manga_Id" });
            DropIndex("dbo.ProductReviews", new[] { "Anime_Id" });
            DropIndex("dbo.ProductReviews", new[] { "User_Id" });
            DropIndex("dbo.Genres", new[] { "Manga_Id" });
            DropIndex("dbo.Genres", new[] { "Anime_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Mangas");
            DropTable("dbo.ExceptionLogs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Characters");
            DropTable("dbo.CharacterReviews");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Genres");
            DropTable("dbo.Animes");
        }
    }
}

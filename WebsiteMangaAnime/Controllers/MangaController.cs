using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Controllers.BaseControllers;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.BaseClasses;
using WebsiteMangaAnime.Models.CacheControl;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Controllers
{
    public class MangaController : SearchController<Manga>
    {
        private IDatabase db;
        private ICache cache;
        private const int pageSize = 20;
        public MangaController()
        {
            db = new Database();
            cache = new Cache();
        }
        public ActionResult BestManga(int? page)
        {
            IPagedList<Manga> mangas = db.GetElements<Manga>()
                .OrderByDescending(x => x.RecommendationsNumber)
                .ToPagedList(page ?? 1, pageSize);
            return View(mangas);
        }
        public ActionResult GetManga(Guid id)
        {
            Manga manga = cache.GetElementById<Manga>(id);
            if (manga == null)
            {
                manga = db.GetElementById<Manga>(id);
                cache.Add(manga, manga.Id);
            }
            return View(manga);
        }
    }
}
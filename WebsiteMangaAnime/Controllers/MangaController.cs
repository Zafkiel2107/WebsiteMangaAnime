using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.CacheControl;
using WebsiteMangaAnime.Models.DatabaseControl;
using WebsiteMangaAnime.Models.Storage;

namespace WebsiteMangaAnime.Controllers
{
    public class MangaController : Controller
    {
        private IDatabase storage;
        private ICache cache;
        private const int pageSize = 20;
        public MangaController()
        {
            storage = new Storage();
            cache = new Cache();
        }
        public ActionResult BestManga(int? page)
        {
            IPagedList<Manga> mangas = storage.GetElements<Manga>()
                .OrderByDescending(x => x.RecommendationsNumber)
                .ToPagedList(page ?? 1, pageSize);
            return View(mangas);
        }
        public ActionResult GetManga(string id)
        {
            Manga manga = storage.GetElementById<Manga>(id);
            return View(manga);
        }
    }
}
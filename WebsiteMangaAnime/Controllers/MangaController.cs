using Ninject;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Controllers
{
    public class MangaController : Controller
    {
        private IDatabase storage;
        private const int pageSize = 20;
        [Inject]
        public MangaController(IDatabase storage)
        {
            this.storage = storage;
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
using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;
using WebsiteMangaAnime.Models.Storage;

namespace WebsiteMangaAnime.Controllers
{
    public class AnimeController : Controller
    {
        private IDatabase storage;
        private const int pageSize = 20;
        public AnimeController()
        {
            this.storage = new Storage();
        }
        public ActionResult BestAnime(int? page)
        {
            IPagedList<Anime> animes = storage.GetElements<Anime>()
                .OrderByDescending(x => x.RecommendationsNumber)
                .ToPagedList(page ?? 1, pageSize);
            return View(animes);
        }
        public ActionResult GetAnime(string id)
        {
            Anime anime = storage.GetElementById<Anime>(id);
            return View(anime);
        }
    }
}
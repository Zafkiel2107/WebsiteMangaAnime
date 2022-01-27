using Ninject;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Controllers
{
    public class AnimeController : Controller
    {
        private IDatabase storage;
        private const int pageSize = 20;
        [Inject]
        public AnimeController(IDatabase storage)
        {
            this.storage = storage;
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
using Ninject;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;
using WebsiteMangaAnime.Models.DataSelection;

namespace WebsiteMangaAnime.Controllers
{
    public class AnimeController : Controller
    {
        private IDatabase storage;
        private DataSelection<Anime> dataSelection;
        private const int pageSize = 20;
        [Inject]
        public AnimeController(IDatabase storage)
        {
            this.storage = storage;
            this.dataSelection = new DataSelection<Anime>(storage);
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
        public ActionResult Search(int? page, string searchValue)
        {
            IPagedList<Anime> animes = dataSelection.Search(page, searchValue);
            return View("BestAnime",animes);
        }
        public ActionResult Filter(int? page, string filter)
        {
            IPagedList<Anime> animes = dataSelection.Filter(page, filter);
            return View("BestAnime", animes);
        }
    }
}
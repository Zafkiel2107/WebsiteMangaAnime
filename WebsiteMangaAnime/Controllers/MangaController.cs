using Ninject;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;
using WebsiteMangaAnime.Models.DataSelection;

namespace WebsiteMangaAnime.Controllers
{
    public class MangaController : Controller
    {
        private IDatabase storage;
        private DataSelection<Manga> dataSelection;
        private const int pageSize = 20;
        [Inject]
        public MangaController(IDatabase storage)
        {
            this.storage = storage;
            this.dataSelection = new DataSelection<Manga>(storage);
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
        public ActionResult Search(int? page, string searchValue)
        {
            IPagedList<Manga> mangas = dataSelection.Search(page, searchValue);
            return View("BestManga", mangas);
        }
        public ActionResult Filter(int? page, string filter)
        {
            IPagedList<Manga> mangas = dataSelection.Filter(page, filter);
            return View("BestManga", mangas);
        }
    }
}
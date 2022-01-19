using PagedList;
using System.Linq;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.BaseClasses;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Controllers
{
    public class HomeController : Controller
    {
        private IDatabase db;
        private const int pageSize = 20;
        public HomeController()
        {
            db = new Database();
        }
        public ActionResult Main() => View();
        public ActionResult Anime(int? page)
        {
            IPagedList<Anime> animes = GetDescElementsPage<Anime>(page);
            return View(animes);
        }
        public ActionResult Manga(int? page)
        {
            IPagedList<Manga> mangas = GetDescElementsPage<Manga>(page);
            return View(mangas);
        }
        private IPagedList<T> GetDescElementsPage<T>(int? page)
            where T : Product
        {
            return db.GetElements<T>()
                .OrderByDescending(x => x.RecommendationsNumber)
                .ToPagedList(page ?? 1, pageSize);
        }
    }
}
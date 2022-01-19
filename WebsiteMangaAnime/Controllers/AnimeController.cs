using System.Web.Mvc;
using WebsiteMangaAnime.Controllers.BaseControllers;

namespace WebsiteMangaAnime.Controllers
{
    public class AnimeController : SearchController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
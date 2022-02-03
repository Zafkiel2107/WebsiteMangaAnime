using System.Web.Mvc;
using WebsiteMangaAnime.Models.LogControl;

namespace WebsiteMangaAnime.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet, ExceptionLogger]
        public ActionResult Main() => View();
    }
}
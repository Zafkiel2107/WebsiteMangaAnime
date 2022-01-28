using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Controllers
{
    public class CharacterController : Controller
    {
        IDatabase storage;
        public CharacterController(IDatabase storage)
        {
            this.storage = storage;
        }
        public ActionResult GetCharacter(string id)
        {
            Character character = storage.GetElementById<Character>(id);
            return View(character);
        }
    }
}
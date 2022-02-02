using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Controllers
{
    public class CharacterReviewController : Controller
    {
        private IDatabase storage;
        public CharacterReviewController(IDatabase storage)
        {
            this.storage = storage;
        }
        [HttpGet, Authorize]
        public ActionResult GetCharacterReview(string id)
        {
            CharacterReview characterReview = storage.GetElements<CharacterReview>()
                .Where(x => x.User.Id == User.Identity.GetUserId()).FirstOrDefault(x => x.Character.Id == id);
            if (characterReview == null)
            {
                characterReview = new CharacterReview();
            }
            return PartialView(characterReview);
        }
        [HttpPost, Authorize]
        public ActionResult PostCharacterReview(CharacterReview characterReview)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
            if (storage.GetElementById<CharacterReview>(characterReview.Id) != null)
            {
                storage.Update<CharacterReview>(characterReview);
            }
            else
            {
                storage.Create<CharacterReview>(characterReview);
            }
            return RedirectToAction("");
        }
    }
    public class ProductReviewController : Controller
    {
        private IDatabase storage;
        public ProductReviewController(IDatabase storage)
        {
            this.storage = storage;
        }
        [HttpGet, Authorize]
        public ActionResult GetProductReview(string id)
        {
            ProductReview productReview = storage.GetElements<ProductReview>()
                .Where(x => x.User.Id == User.Identity.GetUserId()).FirstOrDefault(x => x.Product.Id == id);
            if(productReview == null)
            {
                productReview = new ProductReview();
            }
            return PartialView(productReview);
        }
        [HttpPost, Authorize]
        public ActionResult PostProductReview(ProductReview productReview)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
            if (storage.GetElementById<ProductReview>(productReview.Id) != null)
            {
                storage.Update<ProductReview>(productReview);
            }
            else
            {
                storage.Create<ProductReview>(productReview);
            }
            return RedirectToAction("");
        }
    }
}
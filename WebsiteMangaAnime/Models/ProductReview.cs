using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class ProductReview : Review
    {
        [Required, Display(Name = "Рекомендуется")]
        public bool IsRecommended { get; set; }
        [Required, Display(Name = "Произведение")]
        public virtual Product Product { get; set; }
        [Required, Display(Name = "Пользователь")]
        public virtual IUser User { get; set; }
    }
}
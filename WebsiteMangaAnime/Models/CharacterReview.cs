using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class CharacterReview : Review
    {
        [Required, Display(Name = "Персонаж")]
        public virtual Character Character { get; set; }
        [Required, Display(Name = "Пользователь")]
        public virtual IUser User { get; set; }
    }
}
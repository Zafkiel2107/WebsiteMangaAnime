using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class Manga : Product
    {
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Писатель")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Издатель")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Томов")]
        public byte Tom { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Глав")]
        public short Chapter { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Аннотация")]
        public string MangaLink { get; set; }
    }
}
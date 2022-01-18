using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class Anime : Product
    {
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Режиссер")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Студия")]
        public string Studio { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Сезон")]
        public byte Season { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Серий")]
        public short Series { get; set; }
    }
}
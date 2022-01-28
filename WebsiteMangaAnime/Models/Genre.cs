using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class Genre : Entity
    {
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Жанр")]
        public string GenreName { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class Genre : Entity
    {
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Жанр")]
        public GenreType GenreType { get; set; }
    }
    public enum GenreType : byte
    {
        Сёнэн = 1,
        Комедия = 2,
        Суперспособности = 3,
        Повседневность = 4,
        [Description("Школьная жизнь")]
        ШкольнаяЖизнь = 5,
        Сверхъестественное = 6,
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models
{
    public class Genre
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public Guid GenreId { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Жанр")]
        public GenreType GenreType { get; set; }
        public Genre()
        {
            GenreId = Guid.NewGuid();
        }
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
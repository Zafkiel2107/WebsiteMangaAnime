using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models
{
    public class Character
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public Guid CharacterId { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), DataType(DataType.Date), Display(Name = "Название")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Рост")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Вес")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Range(typeof(double), "0", "10"), Display(Name = "Рейтинг")]
        public double Rating { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Обложка")]
        public virtual Image Image { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Отзывы")]
        public virtual ICollection<CharacterReview> CharacterReviews { get; set; }
        public Character()
        {
            this.CharacterReviews = new List<CharacterReview>();
        }
    }
    public enum Gender : byte
    {
        Мужской = 1,
        Женский = 2,
    }
}
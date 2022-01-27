using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models.BaseClasses
{
    public abstract class Review : Entity
    {
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Рейтинг")]
        public Rating Rating { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Отзыв")]
        public string Content { get; set; }
        [Required, Display(Name = "Проверен")]
        public bool IsChecked { get; set; }
        public Review()
        {
            this.IsChecked = false;
        }
    }
    public enum Rating : byte
    {
        Единица = 1,
        Двойка = 2,
        Тройка = 3,
        Четверка = 4,
        Пятерка = 5,
        Шестерка = 6,
        Семерка = 7,
        Восьмерка = 8,
        Девятка = 9,
        Десятка = 10,
    }
}
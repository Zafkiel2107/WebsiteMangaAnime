using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models.BaseClasses
{
    public abstract class Product
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Статус")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Возрастной рейтинг")]
        public AgeRating AgeRating { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Range(typeof(double), "0", "10"), Display(Name = "Рейтинг")]
        public double Rating { get; set; }
        [Required, Display(Name = "Количество рекомендаций")]
        public int RecommendationsNumber { get; set; }
        [Required, Display(Name = "Жанры")]
        public ICollection<Genre> Genres { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), DataType(DataType.Date), Display(Name = "Год")]
        public DateTime Year { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Обложка")]
        public Image Image { get; set; }
        [Required, Display(Name = "Отзывы")]
        public ICollection<ProductReview> ProductReviews { get; set; }
        public Product()
        {
            //this.Id = Guid.NewGuid(); TODO разобраться с генерацией гуида
            this.RecommendationsNumber = 0;
            this.Genres = new List<Genre>();
            this.ProductReviews = new List<ProductReview>();
        }
    }
    public enum Status : byte
    {
        Анонс = 1,
        Онгоинг = 2,
        Вышел = 3,
    }
    public enum AgeRating : byte
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4,
        RNC17 = 5,
    }
    public enum Genre : byte
    {
        //TODO
    }
}
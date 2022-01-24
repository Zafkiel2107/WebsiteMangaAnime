using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Поле должно быть заполнено"), DataType(DataType.Date), Display(Name = "Возраст")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Аватар")]
        public string ImageLink { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Роль")]
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Отзывы на персонажей")]
        public virtual ICollection<CharacterReview> CharacterReviews { get; set; }
        public User()
        {
            this.ProductReviews = new List<ProductReview>();
            this.CharacterReviews = new List<CharacterReview>();
        }
    }
    public class Role : IdentityRole
    { }
}
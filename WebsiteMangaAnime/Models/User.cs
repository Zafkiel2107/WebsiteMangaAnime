using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models
{
    public class User : IUser<Guid>
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Никнейм")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Возраст")]
        public byte Age { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Аватар")]
        public virtual Image Image { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), DataType(DataType.EmailAddress), Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), HiddenInput(DisplayValue = false)]
        public bool EmailConfirmed { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), DataType(DataType.PhoneNumber), Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), HiddenInput(DisplayValue = false)]
        public bool PhoneNumberConfirmed { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string SecurityStamp { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Роль")]
        public virtual IRole Role { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Отзывы на произведения")]
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Отзывы на персонажей")]
        public virtual ICollection<CharacterReview> CharacterReviews { get; set; }
        public User()
        {
            this.ProductReviews = new List<ProductReview>();
            this.CharacterReviews = new List<CharacterReview>();
        }
    }
}
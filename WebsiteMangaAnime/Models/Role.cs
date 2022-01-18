using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models
{
    public class Role : IRole<Guid>
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Название")]
        public string Name { get; set; }
    }
}
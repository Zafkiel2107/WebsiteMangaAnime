using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models
{
    public class Image
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public Guid ImageId { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено"), Display(Name = "Обложка")]
        public byte[] ImageData { get; set; }
    }
}
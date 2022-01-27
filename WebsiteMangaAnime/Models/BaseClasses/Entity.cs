using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebsiteMangaAnime.Models.BaseClasses
{
    public abstract class Entity
    {
        [Key, Required, HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        public Entity()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
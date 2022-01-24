using System;
using System.ComponentModel.DataAnnotations;
using WebsiteMangaAnime.Models.BaseClasses;

namespace WebsiteMangaAnime.Models.LogControl
{
    public class ExceptionLog : Entity, ILogger
    {
        [Required]
        public string ExceptionMessage { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public string StackTrace { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
    }
}
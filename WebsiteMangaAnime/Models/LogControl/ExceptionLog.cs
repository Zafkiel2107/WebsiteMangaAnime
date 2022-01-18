using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteMangaAnime.Models.LogControl
{
    public class ExceptionLog : ILogger
    {
        [Key, Required]
        public Guid LogId { get; set; }
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
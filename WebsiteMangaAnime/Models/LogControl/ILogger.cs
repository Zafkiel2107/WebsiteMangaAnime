using System;

namespace WebsiteMangaAnime.Models.LogControl
{
    internal interface ILogger
    {
        string ExceptionMessage { get; set; }
        string ControllerName { get; set; }
        string ActionName { get; set; }
        string StackTrace { get; set; }
        DateTime DateTime { get; set; }
    }
}

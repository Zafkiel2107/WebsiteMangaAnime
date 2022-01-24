using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMangaAnime.Models.DatabaseControl;

namespace WebsiteMangaAnime.Models.LogControl
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        IDatabase db;
        public ExceptionLoggerAttribute()
        {
            this.db = new Database();
        }
        public void OnException(ExceptionContext exceptionContext)
        {
            ExceptionLog exceptionLog = new ExceptionLog
            {
                Id = Guid.NewGuid().ToString(),
                ActionName = exceptionContext.RouteData.Values["action"].ToString(),
                ControllerName = exceptionContext.RouteData.Values["controller"].ToString(),
                ExceptionMessage = exceptionContext.Exception.Message,
                StackTrace = exceptionContext.Exception.StackTrace,
                DateTime = DateTime.Now
            };
            db.Create<ExceptionLog>(exceptionLog);
            exceptionContext.ExceptionHandled = true;
        }
    }
}
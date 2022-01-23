using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace WebsiteMangaAnime.Models.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
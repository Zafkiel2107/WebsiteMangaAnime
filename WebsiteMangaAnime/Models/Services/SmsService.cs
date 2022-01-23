using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace WebsiteMangaAnime.Models.Services
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WebsiteMangaAnime.Models.Services
{
    public class SmsService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            string usernameTwilio = ConfigurationManager.AppSettings["usernameTwilio"];
            string passwordTwilio = ConfigurationManager.AppSettings["passwordTwilio"];
            string twilioPhoneNumber = ConfigurationManager.AppSettings["twilioPhoneNumber"];
            TwilioClient.Init(usernameTwilio, passwordTwilio);
            await MessageResource.CreateAsync(
                body: message.Body,
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(message.Destination)
            );
        }
    }
}
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class SmsController : ApiController
    {
        public IHttpActionResult SendSms(Sms sms)
        {
            var accountSid = "ACb3c98567e183f1bf86334829dbe35f83";
            var authToken = "a1fdce30fc27db6fa73d1751b5590012";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+506" + sms.To);
            var from = new PhoneNumber("+14149397843");
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: sms.Body
                );
            return Content(HttpStatusCode.OK, message.Sid);
        }
    }
}

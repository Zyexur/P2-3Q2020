using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;
using System.Net.Mail;

namespace Web_API.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost]
        public IHttpActionResult SendMail(Email email)
        {
            string subject = email.Subject;
            string body = email.Body;
            string to = email.To;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("myspotcr@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("myspotcr@gmail.com", "Myspotcr2020");
            try {
                smtp.Send(mm);
                return Ok("Mensaje enviado exitosamente");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Failed");
            }

        }
    }
}

using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelCore.Areas.Admin.Models;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mail")]
    [Authorize(Roles = "admin")]

    public class MailController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(MailRequest mailRequest)
        {   
            MimeMessage mimeMessage=new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Admin","traversalseyehat@gmail.com");
            
            mimeMessage.From.Add(mailboxAddress);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodybuilder=new BodyBuilder();
            bodybuilder.TextBody = mailRequest.Body;
            mimeMessage.Body=bodybuilder.ToMessageBody();
            mimeMessage.Subject = mailRequest.Subject;
            SmtpClient client= new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalseyehat@gmail.com", "hktuforykobwehxp");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}

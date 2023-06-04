using _Traversal.Areas.Admin.Models;
using BusinessLayer.Helpers.Abstracts;
using BusinessLayer.Helpers.Concrete;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace _Traversal.Areas.Admin.Controllers
{
    public class MailController : BaseController
    {
        private readonly IMailer _mailer;
        public MailController(IMailer mailer)
        {
            _mailer = mailer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mail)
        {

            _mailer.SendMail(mail.ReceiverMail,mail.Subject,mail.Body);


            //MimeMessage mimeMessage = new MimeMessage();


            //MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traversaltestmailxxx@gmail.com");
            //mimeMessage.From.Add(mailboxAddressFrom);

            //MailboxAddress mailboxAddressTo = new MailboxAddress("User",mail.ReceiverMail);
            //mimeMessage.To.Add(mailboxAddressTo);

            //mimeMessage.Subject = mail.Subject;
            ////mimeMessage.Body = mail.Body;
            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = mail.Body;
            //mimeMessage.Body = bodyBuilder.ToMessageBody();

            
            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com",587,false);
            //client.Authenticate("traversaltestmailxxx@gmail.com", "encqeirrxzwhfdav");
            //client.Send(mimeMessage);
            //client.Disconnect(true);

            return View();
        }
    }
}

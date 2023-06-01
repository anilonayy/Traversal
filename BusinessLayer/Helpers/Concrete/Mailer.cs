using BusinessLayer.Helpers.Abstracts;
using DocumentFormat.OpenXml.Spreadsheet;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using BusinessLayer.Models;

namespace BusinessLayer.Helpers.Concrete
{
    public class Mailer : IMailer
    {
        private readonly IConfiguration _configiration;

        public Mailer(IConfiguration configuration)
        {

            _configiration = configuration;
        }
       
        public void SendMail(string To, string Subject, string Content)
        {
            MimeMessage mimeMessage = new MimeMessage();

            EmailInfoVM data = _configiration.GetSection("MailSettings:SenderMail").Get<EmailInfoVM>();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal Tour Guide", data.Mail);
            mimeMessage.From.Add(mailboxAddressFrom);


            MailboxAddress mailboxAddressTo = new MailboxAddress("User", To);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = Content;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            var client = new SmtpClient();
            client.Connect(data.Host, data.Port, false);
            client.Authenticate(data.Mail, data.Password);
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}

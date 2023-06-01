namespace _Traversal.Areas.Admin.Models
{
    public class MailRequest
    {
        public string Name { get; set; } // Gönderen Adı
        public string SenderMail { get; set; } // Gönderen Mail
        public string ReceiverMail { get; set; } // Alıcı
        public string Subject { get; set; } // Başlık
        public string Body { get; set; } // Mesaj içeriği


    }
}

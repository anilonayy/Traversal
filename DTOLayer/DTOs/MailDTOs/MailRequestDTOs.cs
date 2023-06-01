using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MailDTOs
{
    public class MailRequestDTOs
    {
        public string Name { get; set; } // Gönderen Adı
        public string SenderMail { get; set; } // Gönderen Mail
        public string ReceiverMail { get; set; } // Alıcı
        public string Subject { get; set; } // Başlık
        public string Body { get; set; } // Mesaj içeriği
    }
}

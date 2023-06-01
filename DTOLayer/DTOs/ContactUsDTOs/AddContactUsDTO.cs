using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactUsDTOs
{
    public class AddContactUsDTO
    {
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; } = "İletişim Formu";
        public string? MessageBody { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class EmailInfoVM
    {
        public string Host { get; set; }
        public string Mail { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}

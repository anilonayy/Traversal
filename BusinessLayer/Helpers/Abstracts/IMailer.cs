using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers.Abstracts
{
    public interface IMailer
    {
        public void SendMail(string To, string Subject, string Content);
       
    }
}

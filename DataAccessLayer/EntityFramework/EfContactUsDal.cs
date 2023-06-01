using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
     

        public void ChangeStatus(int id)
        {
            using (var context = new Context()) {
                var data = context.ContactUses.Find(id);
                data.MessageStatus = data.MessageStatus == true ? false : true;
                context.SaveChanges();
            }
        }

        public List<ContactUs> GetListByFalse()
        {
            using (var context = new Context())
            {
                return context.ContactUses.Where(x => x.MessageStatus == false).ToList();
            }
        }
        public List<ContactUs> GetListByTrue()
        {
            using (var context = new Context())
            {
                return context.ContactUses.Where(x => x.MessageStatus == true).ToList();
            }
        }
    }
}

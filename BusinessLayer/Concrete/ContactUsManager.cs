using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsService;

        public ContactUsManager(IContactUsDal contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public void TAdd(ContactUs t)
        {
            _contactUsService.Insert(t);
        }

        public void TChangeStatus(int id)
        {
            _contactUsService.ChangeStatus(id);
        }

        public void TDelete(ContactUs t)
        {
            _contactUsService.Delete(t);
        }

        public ContactUs TGetById(int id)
        {
            return _contactUsService.GetById(id);
        }

        public List<ContactUs> TGetList()
        {
            return _contactUsService.GetList();
        }

        public List<ContactUs> TGetListByFalse()
        {
           return _contactUsService.GetListByFalse();
        }

        public List<ContactUs> TGetListByFilter(Expression<Func<ContactUs, bool>> filter)
        {
            return _contactUsService.GetListByFilter(filter);
        }

        public List<ContactUs> TGetListByTrue()
        {
            return _contactUsService.GetListByTrue();
        }

        public void TUpdate(ContactUs t)
        {
             _contactUsService.Update(t);
        }
    }
}

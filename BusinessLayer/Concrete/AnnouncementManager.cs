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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _service;

        public AnnouncementManager(IAnnouncementDal service)
        {
            _service = service;
        }

        public void TAdd(Announcement t)
        {
            _service.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            _service.Delete(t);
        }

        public Announcement TGetById(int id)
        {
           return _service.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return   _service.GetList();
        }

        public List<Announcement> TGetListByFilter(Expression<Func<Announcement, bool>> func)
        {
            return _service.GetListByFilter(func);
        }

        public void TUpdate(Announcement t)
        {
            _service.Update(t);
        }
    }
}

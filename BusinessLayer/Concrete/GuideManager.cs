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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal manager;
        public GuideManager(IGuideDal _manager)
        {
            manager = _manager;
        }

        public void ChangeStatus(int id)
        {
            manager.ChangeStatus(id);
        }

        public void TAdd(Guide t)
        {
            manager.Insert(t);
        }

        public void TDelete(Guide t)
        {
            manager.Delete(t);
        }

        public Guide TGetById(int id)
        {
            return manager.GetById(id);
        }

        public List<Guide> TGetList()
        {
           return  manager.GetList();
        }

        public List<Guide> TGetListByFilter(Expression<Func<Guide, bool>> func)
        {
            return manager.GetListByFilter(func);
        }

        public void TUpdate(Guide t)
        {
            manager.Update(t);
        }
    }
}

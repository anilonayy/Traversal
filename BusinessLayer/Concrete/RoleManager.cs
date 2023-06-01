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
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void TAdd(AppRole t)
        {
            _roleDal.Insert(t);
        }

        public void TDelete(AppRole t)
        {
            _roleDal.Delete(t);
        }

        public AppRole TGetById(int id)
        {
            return _roleDal.GetById(id);
        }

        public List<AppRole> TGetList()
        {
            return _roleDal.GetList();
        }

        public List<AppRole> TGetListByFilter(Expression<Func<AppRole, bool>> func)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppRole t)
        {
             _roleDal.Update(t);
        }
    }
}

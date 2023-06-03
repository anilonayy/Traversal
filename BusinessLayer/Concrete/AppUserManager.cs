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
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _dal;
        public AppUserManager(IAppUserDal dal)
        {
            _dal = dal;
        }



        public void TAdd(AppUser t)
        {
            _dal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _dal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Comment> TGetComments(int userId)
        {
            return _dal.GetComments(userId);
        }

        public List<AppUser> TGetList()
        {
            return _dal.GetList();
        }

        public List<AppUser> TGetListByFilter(Expression<Func<AppUser, bool>> filter)
        {
            return _dal.GetListByFilter(filter);
        }

        public List<AppUser> TGetListByFilter(Expression<Func<AppUser, bool>> filter, Expression<Func<AppUser, object>> include)
        {
            return _dal.GetListByFilter(filter,include);
        }

        public void TUpdate(AppUser t)
        {
            _dal.Update(t);
        }
    }
}

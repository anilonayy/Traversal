using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter,Expression<Func<T,object>> include);
        T GetById(int id);

    }
}

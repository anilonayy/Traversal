using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public Context _context = new Context();
        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().AsNoTracking().ToList();   
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
        
        public List<T> GetListByFilter(Expression<Func<T,bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }
        public List<T> GetListByFilter(Expression<Func<T, bool>> filter, Expression<Func<T, object>> include)
        {
            return _context.Set<T>().Include(include).Where(filter).ToList();
        }


    }
}

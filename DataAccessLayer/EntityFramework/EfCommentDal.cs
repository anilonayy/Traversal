using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly Context _context = new Context();

        public List<Comment> GetCommentsWithUserAndDestination(int destinationId)
        {
            return _context.Comments.AsNoTracking().Include(x => x.AppUser).Include(x => x.Destination).Where(x => x.DestinationId == destinationId).ToList();
        }
        public List<Comment> GetCommentsWithUserAndDestination()
        {
            return _context.Comments.AsNoTracking().Include(x => x.AppUser).Include(x => x.Destination).ToList();
        }

        public List<Comment> GetListByFilter(Expression<Func<Comment, bool>> filter)
        {
            return _context.Comments.AsNoTracking().Where(filter).ToList();

        }
        public List<Comment> GetListByFilter(Expression<Func<Comment, bool>> filter, Expression<Func<Comment, object>> include)
        {
            return _context.Comments.AsNoTracking().Include(include).Where(filter).ToList();
        }
    }
}

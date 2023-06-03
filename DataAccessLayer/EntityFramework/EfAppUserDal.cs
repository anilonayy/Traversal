using DataAccessLayer.Abstract;
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
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public List<Comment> GetComments(int userId)
        {
            return 
                _context
                .Comments
                .AsNoTracking()
                .Include(x => x.AppUser)
                .Include(x => x.Destination)
                .Where(x => x.AppUserId == userId)
                .ToList();
        }
    }
}

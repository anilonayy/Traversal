using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;


namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeStatus(int id)
        {
            var guide = _context.Guides.Find(id);
            guide.Status = !guide.Status;
            _context.SaveChanges();
        }
    }
}

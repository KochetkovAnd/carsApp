using carsApp.Data;
using carsApp.Interfaces;
using carsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace carsApp.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly DataContext _context;
        public AnnouncementRepository(DataContext context)
        {
            _context = context;    
        }
         
        

        public ICollection<Announcement> GetAll()
        {
            //return _context.Announcements.OrderBy(a => a.Id).ToList();
            return _context.Announcements.Include(a => a.Car).Include(a => a.Photos).OrderBy(a => a.Id).ToList();
        }
        public Announcement GetById(int id)
        {
            return _context.Announcements.Include(a => a.Car).Include(a => a.Photos).Where(a => a.Id == id).FirstOrDefault();
        }
        public bool Exist(int id)
        {
            return _context.Announcements.Any(a => a.Id == id);
        }

        public ICollection<Announcement> GetNRandom(int n)
        {
            return _context.Announcements.Include(a => a.Car).Include(a => a.Photos).Take(n).ToList();
        }
    }
}

using carsApp.Models;

namespace carsApp.Interfaces
{
    public interface IAnnouncementRepository
    {
        ICollection<Announcement> GetAll();
        ICollection<Announcement> GetNRandom(int n);
        Announcement GetById(int id);
        bool Exist(int id);
    }
}

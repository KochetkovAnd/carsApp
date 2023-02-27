using carsApp.Data;
using carsApp.Interfaces;
using carsApp.Models;

namespace carsApp.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }     
        public ICollection<Car> GetAll()
        {
            return _context.Cars.OrderBy(c => c.Id).ToList();
        }
        public Car GetById(int id)
        {
            return _context.Cars.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool Exist(int id)
        {
            return _context.Cars.Any(c => c.Id == id);
        }

        public bool Create(Car car)
        {
            _context.Cars.Add(car);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Delete(Car car)
        {
            _context.Remove(car);
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

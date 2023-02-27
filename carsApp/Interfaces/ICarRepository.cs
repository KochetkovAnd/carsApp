using carsApp.Models;

namespace carsApp.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetAll();        
        Car GetById(int id);
        bool Create(Car car);
        bool Delete(Car car);
        bool Exist(int id);

    }
}

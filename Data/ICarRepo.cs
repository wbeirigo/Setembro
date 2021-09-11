using System.Collections.Generic;
using CarService.Models;

namespace CarService.Data
{
    public interface ICarRepo
    {
        bool SaveChanges();

        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void CreateCar(Car car);
    }
}
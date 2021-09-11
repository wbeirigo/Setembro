using System;
using System.Collections.Generic;
using System.Linq;
using CarService.Models;

namespace CarService.Data
{
    public class CarRepo : ICarRepo
    {
        
        private readonly AppDbContext _context;

        public CarRepo(AppDbContext context)
        {
            _context = context;
        }


        public void CreateCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _context.Car.Add(car);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Car.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Car.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
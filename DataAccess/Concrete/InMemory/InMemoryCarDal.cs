using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
            new Car() { Id = 1 , BrandId = 2, ColorId = 5 , DailyPrice= 2500 ,ModelYear = 2014 ,Description = "Açıklama" },
            new Car() { Id = 2 , BrandId = 5, ColorId = 1 , DailyPrice= 2000 ,ModelYear = 2018 ,Description = "Açıklama" },
            new Car() { Id = 3 , BrandId = 3, ColorId = 3 , DailyPrice= 5000 ,ModelYear = 2021 ,Description = "Açıklama" },
            new Car() { Id = 4 , BrandId = 7, ColorId = 2 , DailyPrice= 4500 ,ModelYear = 2022 ,Description = "Açıklama" },
            new Car() { Id = 5 , BrandId = 9, ColorId = 9 , DailyPrice= 2750 ,ModelYear = 2009 ,Description = "Açıklama" }

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
             var carToDelete = _cars.SingleOrDefault(c=> c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c=> c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}

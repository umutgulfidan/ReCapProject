using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;   
        }

        public void Add(Car car)
        {
            //iş kodları
            if(car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }

        }

        public void Delete(Car car)
        {
             _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(car=> car.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(car=> car.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}

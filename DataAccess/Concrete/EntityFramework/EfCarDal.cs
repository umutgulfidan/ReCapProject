using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.Id equals carImage.CarId into carImagesGroup
                             from carImage in carImagesGroup.DefaultIfEmpty()
                             group carImage by new
                             {
                                 car.Id,
                                 car.CarName,
                                 brand.BrandName,
                                 color.ColorName,
                                 car.DailyPrice,
                                 car.Description
                             } into groupedCarImages
                             select new CarDetailDto
                             {
                                 Id = groupedCarImages.Key.Id,
                                 CarName = groupedCarImages.Key.CarName,
                                 BrandName = groupedCarImages.Key.BrandName,
                                 ColorName = groupedCarImages.Key.ColorName,
                                 DailyPrice = groupedCarImages.Key.DailyPrice,
                                 Description = groupedCarImages.Key.Description,
                                 CarImages = groupedCarImages
                                             .Where(ci => ci != null)
                                             .Select(ci => new CarImage
                                             {
                                                 Id = ci.Id,
                                                 CarId = ci.CarId,
                                                 Date = ci.Date,
                                                 ImagePath = ci.ImagePath
                                             })
                                             .ToArray()
                             };

                var finalResult = result.ToList();

                return finalResult;
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.Id equals carImage.CarId into carImagesGroup
                             from carImage in carImagesGroup.DefaultIfEmpty()
                             where car.BrandId == brandId 
                             group carImage by new
                             {
                                 car.Id,
                                 car.CarName,
                                 brand.BrandName,
                                 color.ColorName,
                                 car.DailyPrice,
                                 car.Description
                             } into groupedCarImages
                             select new CarDetailDto
                             {
                                 Id = groupedCarImages.Key.Id,
                                 CarName = groupedCarImages.Key.CarName,
                                 BrandName = groupedCarImages.Key.BrandName,
                                 ColorName = groupedCarImages.Key.ColorName,
                                 DailyPrice = groupedCarImages.Key.DailyPrice,
                                 Description = groupedCarImages.Key.Description,
                                 CarImages = groupedCarImages
                                             .Where(ci => ci != null)
                                             .Select(ci => new CarImage
                                             {
                                                 Id = ci.Id,
                                                 CarId = ci.CarId,
                                                 Date = ci.Date,
                                                 ImagePath = ci.ImagePath
                                             })
                                             .ToArray()
                             };

                var finalResult = result.ToList();

                return finalResult;
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join carImage in context.CarImages on car.Id equals carImage.CarId into carImagesGroup
                             from carImage in carImagesGroup.DefaultIfEmpty()
                             where car.ColorId == colorId
                             group carImage by new
                             {
                                 car.Id,
                                 car.CarName,
                                 brand.BrandName,
                                 color.ColorName,
                                 car.DailyPrice,
                                 car.Description
                             } into groupedCarImages
                             select new CarDetailDto
                             {
                                 Id = groupedCarImages.Key.Id,
                                 CarName = groupedCarImages.Key.CarName,
                                 BrandName = groupedCarImages.Key.BrandName,
                                 ColorName = groupedCarImages.Key.ColorName,
                                 DailyPrice = groupedCarImages.Key.DailyPrice,
                                 Description = groupedCarImages.Key.Description,
                                 CarImages = groupedCarImages
                                             .Where(ci => ci != null)
                                             .Select(ci => new CarImage
                                             {
                                                 Id = ci.Id,
                                                 CarId = ci.CarId,
                                                 Date = ci.Date,
                                                 ImagePath = ci.ImagePath
                                             })
                                             .ToArray()
                             };

                var finalResult = result.ToList();

                return finalResult;
            }
        }
    }
}

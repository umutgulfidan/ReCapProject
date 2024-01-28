
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
        AddTest();

        DtoTest();

        UpdateTest();

    }

    private static void UpdateTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        ColorManager colorManager = new ColorManager(new EfColorDal());
        carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 1, CarName = "Update Test", DailyPrice = 1000, ModelYear = 2024 });
        brandManager.Update(new Brand { BrandId = 1, BrandName = "UpdateTest" });
        colorManager.Update(new Color { ColorId = 1, ColorName = "Beyaz" });
        DtoTest();
    }

    private static void DtoTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var item in carManager.GetCarDetails().Data)
        {
            Console.WriteLine(item.CarName + " " + item.BrandName + " " + item.ColorName);

        }
    }

    private static void AddTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        colorManager.Add(new Color() { ColorName = "Siyah" });
        foreach (var item in colorManager.GetAll().Data)
        {
            Console.WriteLine(item.ColorName);
        }
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        brandManager.Add(new Brand() { BrandName = "TOGG" });
        foreach (var item in brandManager.GetAll().Data)
        {
            Console.WriteLine(item.BrandName);
        }
        CarManager carManager = new CarManager(new EfCarDal());
        carManager.Add(new Car() { BrandId = 1, ColorId = 1, CarName = "Test", Description = "Test", DailyPrice = 550, ModelYear = 2000});
        foreach (var item in carManager.GetAll().Data)
        {
            Console.WriteLine(item.CarName);
        }
    }
}


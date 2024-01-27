
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        colorManager.Add(new Color() { ColorName="Turkuaz"});
        foreach (var item in colorManager.GetAll())
        {
            Console.WriteLine(item.ColorName);
        }
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        brandManager.Add(new Brand() { BrandName = "Togg" });
        foreach (var item in brandManager.GetAll())
        {
            Console.WriteLine(item.BrandName);
        }
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine(item.CarName);
        }
    }

}


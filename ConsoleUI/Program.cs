
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());
        Yazdir(carManager);
        carManager.Add(new Car() { Id =10 , BrandId = 10 , ColorId = 10 ,DailyPrice = 1000 ,ModelYear = 2024 , Description = "Test" } );
        Yazdir(carManager);
        var car = carManager.GetById(5);
        Console.WriteLine("{0} , {1}",car.Id,car.DailyPrice);
        Console.WriteLine("-------------------------");
        carManager.Delete(carManager.GetById(3));
        Yazdir(carManager);
        var car2 = carManager.GetById(4);
        car2.DailyPrice = 999;
        carManager.Update(car2);
        Yazdir(carManager);


    }
    public static void Yazdir(CarManager carManager)
    {
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine($"{car.Id} : {car.DailyPrice}");
        }
        Console.WriteLine("------------------------------------");
    }
}


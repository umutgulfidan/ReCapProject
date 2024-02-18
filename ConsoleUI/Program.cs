
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        //    AddTest(); +
        //    DtoTest(); +
        //    UpdateTest(); +

        // UserTest(); +
        // CustomerTest(); +
        RentalTest();

    }
    private static void RentalTest()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        rentalManager.Add(new Rental() { CarId=1,UserId=1,RentDate=DateTime.Now,ReturnDate=null});

        //Burada patlaması lazım çünnkü öncesinde arabayı kiralattık ve dönmedi ReturnDate = null
        var result = rentalManager.Add(new Rental() { CarId = 1, UserId = 1, RentDate = DateTime.Now, ReturnDate = null }).IsSuccess
            ? "Eklendi" : "Eklenemedi";
        Console.WriteLine(result);
    }
    private static void UserTest()
    {
        UserManager userManager = new UserManager(new EfUserDal());
        userManager.Add(new User() { FirstName = "Test",LastName="DENEME",Email="deneme@gmail.com" });
        userManager.Update(new User() { Id = 1, FirstName = "Test", LastName = "Test User Updated", Email = "deneme@gmail.com"});
        userManager.Add(new User() { FirstName = "Test2", LastName = "DENEME", Email = "deneme@gmail.com" });
        userManager.Add(new User() { FirstName = "Test3", LastName = "DENEME", Email = "deneme@gmail.com" });
        userManager.GetAll().Data.ForEach(u => Console.WriteLine(u.FirstName + "  " + u.LastName));
        userManager.Delete(new User() { Id = 3 });
        userManager.GetAll().Data.ForEach(u => Console.WriteLine(u.FirstName + "  " + u.LastName));
    }
    private static void CustomerTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        customerManager.Add(new Customer() { UserId =1 ,CompanyName= "TEST COMPANY"});
        customerManager.Update(new Customer() { Id = 1,UserId = 1, CompanyName = "Test Company Updated" });
        customerManager.Add(new Customer() { UserId=2,CompanyName = "Silinecek Customer"});
        customerManager.GetAll().Data.ForEach(c=> Console.WriteLine(c.UserId +"  "+c.CompanyName));
        customerManager.Delete(new Customer() { Id= 2 });
        customerManager.GetAll().Data.ForEach(c => Console.WriteLine(c.UserId + "  " + c.CompanyName));
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


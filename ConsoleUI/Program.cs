using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.Dtos;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EFCarDal());
            
            Console.WriteLine("---------All Description-----------");
            carService.GetAll().ForEach(f => Console.WriteLine("\n" + f.Description));

            Console.WriteLine("\n---------Brand Condition-----------");
            carService.GetAllByBrandId(2).ForEach(f => Console.WriteLine("\n" + f.Description));

            Console.WriteLine("\n---------Color Condition-----------");
            Car Ccar = carService.GetCarsByColorId(2);
            Console.WriteLine("\n" + Ccar.Description);

            Console.WriteLine("\n---------Car Detail-----------");
            List<CarDetail> detailCarList = carService.GetCarDetails();
            foreach (var cDetail in detailCarList)
            {
                Console.WriteLine("\n" + "Brand : " + cDetail.CarName + " | " + "Color : " + cDetail.ColorName + " | " + "DailyPrice :  " + cDetail.DailyPrice);
            }

            Console.ReadLine();
        }
    }
}
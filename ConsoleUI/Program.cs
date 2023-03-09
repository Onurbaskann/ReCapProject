using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EFCarDal());
            
            Console.WriteLine("---------All Data-----------");
            carService.GetAll().ForEach(f => Console.WriteLine("\n" + f.Description));
            Console.WriteLine("\n---------Brand-----------");
            carService.GetAllByBrandId(2).ForEach(f => Console.WriteLine("\n" + f.Description));
            Console.WriteLine("\n---------Color-----------");
            Car Ccar = carService.GetCarsByColorId(2);
            Console.WriteLine(Ccar.Description);
            Console.ReadLine();
        }
    }
}
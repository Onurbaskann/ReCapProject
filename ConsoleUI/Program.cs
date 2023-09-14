using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
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
            #region Car 
            //AllDescription();
            //BrandCondition();
            //ColorCondition();
            //CarDetail();
            #endregion

            #region Customer
            //GetCustomersInformation();
            #endregion

            #region Rental
            //GetRentalsInformation();
            #endregion

            Console.ReadLine();
        }
        #region Methods
        private static void GetRentalsInformation()
        {
            IRentalService rentalService = new RentalManager(new EFRentalDal());

            Console.WriteLine("\n---------Get Rentals Information-----------");

            foreach (var rental in rentalService.GetRentalDetails().Data)
            {
                Console.WriteLine("\n" + "First Name : " + rental.FirstName + " | LastName : " + rental.LastName + " | Company Name : " + rental.CompanyName + " | Brand : " + rental.BrandName + " | Color : " + rental.ColorName + " | Rent Date : " + rental.RentDate.ToShortDateString() + " | Return Date : " + (rental.ReturnDate.HasValue ? rental.ReturnDate.Value.ToShortDateString() : string.Empty));
            }
        }

        private static void GetCustomersInformation()
        {
            ICustomerService customerService = new CustomerManager(new EFCustomerDal());

            Console.WriteLine("\n---------Get Customers Information-----------");
            foreach (var customer in customerService.GetCustomerDetails().Data)
            {
                Console.WriteLine("\n" + "First Name : " + customer.FirstName + " | " + "Last Name : " + customer.LastName + " | Company Name : " + customer.CompanyName + " | " + "Email : " + customer.Email);
            }
        }
        
        private static void CarDetail()
        {
            ICarService carService = new CarManager(new EFCarDal());

            Console.WriteLine("\n---------Car Detail-----------");
            List<CarDetail> detailCarList = carService.GetCarDetails().Data;
            foreach (var cDetail in detailCarList)
            {
                Console.WriteLine("\n" + "Brand : " + cDetail.BrandName + " | Color : " + cDetail.ColorName + " | DailyPrice :  " + cDetail.DailyPrice);
            }
        }

        private static void ColorCondition()
        {
            ICarService carService = new CarManager(new EFCarDal());

            Console.WriteLine("\n---------Color Condition-----------");
            Car Ccar = carService.GetCarsByColorId(2).Data;
            Console.WriteLine("\n" + Ccar.Description);
        }

        private static void BrandCondition()
        {
            ICarService carService = new CarManager(new EFCarDal());

            Console.WriteLine("\n---------Brand Condition-----------");
            carService.GetAllByBrandId(2).Data.ForEach(f => Console.WriteLine("\n" + f.Description));
        }

        private static void AllDescription()
        {
            ICarService carService = new CarManager(new EFCarDal());

            Console.WriteLine("---------All Description-----------");
            carService.GetAll().Data.ForEach(f => Console.WriteLine("\n" + f.Description));
        }
        #endregion Methods
    }
}
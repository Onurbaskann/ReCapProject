using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int Id)
        {
            return _carDal.GetAll(b => b.BrandId == Id);
        }

        public List<CarDetail> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public Car GetCarsByColorId(int Id)
        {
            return _carDal.Get(c => c.ColorId == Id);
        }
    }
}

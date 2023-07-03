using Business.Abstract;
using Core.Constants;
using Core.Utilities.Result;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Message.SuccessAddedCar);
            }
            return new ErrorResult(Message.ErrorAddedCar);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Message.SuccessListedCars);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == Id));
        }

        public IDataResult<List<CarDetail>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetail>>(_carDal.GetCarDetails(), Message.SuccessListedCarsDetail);
        }

        public IDataResult<Car> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == Id), Message.SuccessGetCarByColor);
        }
    }
}

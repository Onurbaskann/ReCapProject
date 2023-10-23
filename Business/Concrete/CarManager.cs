using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

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
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarAddError);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == Id));
        }

        public IDataResult<List<CarDetail>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetail>>(_carDal.GetCarDetails(), Messages.CarDetailListed);
        }

        public IDataResult<Car> GetCarsByColorId(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == Id), Messages.CarByColorListed);
        }
    }
}

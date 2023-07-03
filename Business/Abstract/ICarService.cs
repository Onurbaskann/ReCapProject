using Core.Utilities.Result;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int Id);
        IDataResult<Car> GetCarsByColorId(int id);
        IResult Add(Car car);
        IDataResult<List<CarDetail>> GetCarDetails();
    }
}

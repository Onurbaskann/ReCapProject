using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId = 1, BrandId = 1, ColorId =2, ModelYear = 2004, DailyPrice = 415000, Description = "Volkswagen Polo 1.2 TSI"},
                new Car {CarId = 2, BrandId = 1, ColorId =1, ModelYear = 2016, DailyPrice = 728000, Description = "Volkswagen Passat 1.6 TDI"},
                new Car {CarId = 3, BrandId = 2, ColorId =2, ModelYear = 2020, DailyPrice = 536000, Description = "Ford Ecosport 1.0i"},
                new Car {CarId = 4, BrandId = 2, ColorId =2, ModelYear = 2015, DailyPrice = 430000, Description = "Ford Focus III 1.6 MCA"},
                new Car {CarId = 5, BrandId = 3, ColorId =2, ModelYear = 2012, DailyPrice = 448000, Description = "Skoda Superb 1.4 TSI"},
                new Car {CarId = 6, BrandId = 4, ColorId =3, ModelYear = 2020, DailyPrice = 463000, Description = "Fiat Egea 1.3 MULTIJET"},
                new Car {CarId = 7, BrandId = 5, ColorId =1, ModelYear = 2013, DailyPrice = 344000, Description = "Opel Astra 1.3 CDTI"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(x => x.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.FirstOrDefault(filter.Compile());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? _cars.ToList() : _cars.Where(filter.Compile()).ToList();
        }

        public void Update(Car car)
        {
            Car carToUptade = _cars.FirstOrDefault(x => x.CarId == car.CarId);
            
            car.BrandId = carToUptade.BrandId;
            car.ColorId = carToUptade.ColorId;
            car.ModelYear = carToUptade.ModelYear;
            car.DailyPrice = carToUptade.DailyPrice;
            car.Description = carToUptade.Description;
        }
    }
}

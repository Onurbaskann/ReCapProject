using Business.Abstract;
using Business.Aspect.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [CacheRemoveAspect("Get")]
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate.HasValue)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
                return new ErrorResult(Messages.ReturnDateMissing);
        }
        [CacheRemoveAspect("Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == id), Messages.RentalListed);
        }
        [SecuredOperation("rental.getall,admin")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }
        [CacheAspect]
        public IDataResult<List<RentalDetail>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetail>>(_rentalDal.GetRentalDetails(), Messages.RentalDetailListed);
        }
        [CacheRemoveAspect("Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

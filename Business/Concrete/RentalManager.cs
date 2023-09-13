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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate.HasValue)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.SuccessAddedRental);
            }
            else
                return new ErrorResult(Message.ErrorNoReturnDate);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.SuccessDeletedRental);
        }

        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.Id == id), Message.SuccessListedRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.SuccessListedRentals);
        }

        public IDataResult<List<RentalDetail>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetail>>(_rentalDal.GetRentalDetails(), Message.SuccessListedRentalsDetail);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.SuccessUpdatedRental);
        }
    }
}

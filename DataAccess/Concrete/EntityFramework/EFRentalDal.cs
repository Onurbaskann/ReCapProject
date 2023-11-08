using Core.DataAccess.EnitityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EfEnitityRepositoryBase<Rental,RecapContext>,IRentalDal
    {
        public List<RentalDetail> GetRentalDetails()
        {
            using(RecapContext context = new RecapContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join ca in context.Cars on r.CarId equals ca.CarId
                             join u in context.Users on cu.UserId equals u.Id
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             join b in context.Brands on ca.BrandId equals b.BrandId
                             select new RentalDetail
                             {
                                 Id = r.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}

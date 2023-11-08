using Core.DataAccess.EnitityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal:EfEnitityRepositoryBase<Customer,RecapContext>,ICustomerDal
    {
        public List<CustomerDetail> GetCustomerDetails()
        {
            using (var context = new RecapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetail
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}

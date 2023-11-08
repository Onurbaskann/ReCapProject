using Core.Entites.Concrete;
using Core.Utilities.Result;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetbyEmail(string email);
    }
}

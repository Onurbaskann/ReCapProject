using Business.Abstract;
using Core.Entites.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult();
        }
        public IDataResult<User> GetbyEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);

            return new SuccessDataResult<User>(result);
        }
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);

            return new SuccessDataResult<List<OperationClaim>>(result);
        }
    }
}

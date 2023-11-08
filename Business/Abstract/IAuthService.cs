using Core.Entites.Concrete;
using Core.Utilities.Helper.Security.JWT;
using Core.Utilities.Result;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

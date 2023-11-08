using Core.Entites.Concrete;

namespace Core.Utilities.Helper.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> claims);
    }
}

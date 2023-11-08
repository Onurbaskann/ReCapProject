using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Helper.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey secuerityKey)
        {
            return new SigningCredentials(secuerityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
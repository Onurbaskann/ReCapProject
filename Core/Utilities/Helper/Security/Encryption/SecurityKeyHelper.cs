using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Helper.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string SecurityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
        }
    }
}
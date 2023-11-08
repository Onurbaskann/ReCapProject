using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Helper.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordsSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordsSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordsSalt)
        {
            using (var hmac = new HMACSHA512(passwordsSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}

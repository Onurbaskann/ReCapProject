namespace Core.Utilities.Helper.GuidHelper
{
    public class GuildHelper
    {
        public static string GetGuidtoString()
        {
            return Guid.NewGuid().ToString();
        }
        public static Guid GetGuid()
        {
            return Guid.NewGuid();
        }
        public static string GetCustomGuid(string str)
        {
            return Guid.NewGuid().ToString() + "_" + str;
        }
    }
}

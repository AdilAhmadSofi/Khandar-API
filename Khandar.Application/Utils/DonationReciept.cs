using System.Security.Cryptography;

namespace Khandar.Application.Utils
{
    public class DonationReciept
    {
        public static string GenerateReciept()
        {
            return "eKhandar-" + (RandomNumberGenerator.GetInt32(1111, 9999).ToString());
        }
    }
}

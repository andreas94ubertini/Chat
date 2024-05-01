using System.Security.Cryptography;
using System.Text;

namespace ChatApi.Models
{
    public class MD5Helper
    {
        public static string CalculateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the hash to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Format each byte as a two-character hexadecimal value
                }

                return sb.ToString();
            }
        }
    }
}

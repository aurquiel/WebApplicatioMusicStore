using System.Security.Cryptography;
using System.Text;

namespace WebApplicatioMusicStore.Utils
{
    public static class Hash256
    {
        public static string HashOfUserPassword(string password)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach (Byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
            }

            return Sb.ToString();
        }
    }
}

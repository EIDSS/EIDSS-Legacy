using System.Security.Cryptography;
using System.Text;

namespace eidss.model.Core
{
    public static class SecurityHelper
    {
        public static byte[] GetPasswordHash(string password)
        {
            return SHA1.Create().ComputeHash(Encoding.Unicode.GetBytes(password));
        }
    }
}

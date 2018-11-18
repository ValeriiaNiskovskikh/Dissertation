using System.Security.Cryptography;
using System.Text;

namespace Core.Services
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5
    /// </summary>
    public class PasswordService : IPasswordService
    {
        public string Encrypt(string password, string salt)
        {
            var firstStep = CreateMd5(password);
            var result = CreateMd5($"{firstStep}{salt}");
            return result;
        }

        private static string CreateMd5(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                foreach (var t in hashBytes)
                    sb.Append(t.ToString("X2"));

                return sb.ToString();
            }
        }
    }
}
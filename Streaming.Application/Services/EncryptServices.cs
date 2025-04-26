using System.Security.Cryptography;
using System.Text;

namespace Streaming.Application.Services
{
    public class EncryptServices
    {
        public static (string passwordHash, string salt) EncryptPassword(string password)
        {
            byte[] saltBytes = GenerateSalt();
            string salt = Convert.ToBase64String(saltBytes);

            using SHA256 sha256 = SHA256.Create();

            byte[] combinedBytes = CombineBytes(Encoding.UTF8.GetBytes(password), saltBytes);
            byte[] hashedBytes = sha256.ComputeHash(combinedBytes);

            var builder = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                builder.Append(hashedBytes[i].ToString("x2"));

            return (builder.ToString(), salt);
        }

        public static bool VerifyPassword(string password, string salt, string passwordHash)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            using SHA256 sha256 = SHA256.Create();

            byte[] combinedBytes = CombineBytes(Encoding.UTF8.GetBytes(password), saltBytes);
            byte[] hashedBytes = sha256.ComputeHash(combinedBytes);

            var builder = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                builder.Append(hashedBytes[i].ToString("x2"));

            return builder.ToString() == passwordHash;
        }

        private static byte[] CombineBytes(byte[] bytes1, byte[] bytes2)
        {
            byte[] bytes = new byte[bytes1.Length + bytes2.Length];

            Buffer.BlockCopy(bytes1, 0, bytes, 0, bytes1.Length);
            Buffer.BlockCopy(bytes2, 0, bytes, bytes1.Length, bytes2.Length);

            return bytes;
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];

            RandomNumberGenerator.Create().GetBytes(salt);
            return salt;
        }
    }
}

using domaren.realstate.Domain.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace domaren.realstate.Domain.Services
{
    public class PasswordHashProvider : IPasswordHashProvider
    {
        private const int SaltSize = 16;
        private const int Iterations = 10000;

        public string EncryptPassword(string password)
        {
 
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var salt = GenerateSalt();

            var hashedPasswordBytes = Rfc2898DeriveBytes.Pbkdf2(passwordBytes, salt, Iterations, HashAlgorithmName.SHA512, SaltSize);

            var hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
            var stringSalt = Convert.ToBase64String(salt);

            return $"{stringSalt}.{hashedPassword}";
        }

        public bool DecryptPassword(string hash, string password) 
        { 
            var parts = hash.Split('.');

            if (parts.Length > 2)
                throw new ArgumentException("Hash has more than two parts");

            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var salt = Convert.FromBase64String(parts[0]);
            var key = Convert.FromBase64String(parts[1]);

            var keyToVerify = Rfc2898DeriveBytes.Pbkdf2(passwordBytes, salt, Iterations, HashAlgorithmName.SHA512, SaltSize);
            return keyToVerify.SequenceEqual(key);
        }

        static byte[] GenerateSalt()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }
}

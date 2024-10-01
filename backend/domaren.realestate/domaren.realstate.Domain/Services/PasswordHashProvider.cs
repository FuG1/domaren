using domaren.realstate.Domain.Contracts;
using System.Security.Cryptography;

namespace domaren.realstate.Domain.Services
{
    public class PasswordHashProvider : IPasswordHashProvider
    {
        private const int SaltSize = 16;
        private const int Iterations = 10000;

        public string EncryptPassword(string password)
        {
            var rfc = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA512);
            var key = Convert.ToBase64String(rfc.GetBytes(SaltSize));
            var salt = Convert.ToBase64String(rfc.Salt);

            return $"{key}-{salt}";
        }
    }
}

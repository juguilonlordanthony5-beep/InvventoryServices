using System;
using System.Security.Cryptography;

namespace InvventoryServices
{
    internal static class PasswordHelper
    {
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 32; // 256 bit
        private const int Iterations = 100_000;

        public static void CreateHash(string password, out byte[] salt, out byte[] hash)
        {
            if (password is null) throw new ArgumentNullException(nameof(password));

            salt = RandomNumberGenerator.GetBytes(SaltSize);
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            hash = pbkdf2.GetBytes(HashSize);
        }

        public static bool Verify(string password, byte[] salt, byte[] expectedHash)
        {
            if (password is null) throw new ArgumentNullException(nameof(password));
            if (salt is null) throw new ArgumentNullException(nameof(salt));
            if (expectedHash is null) throw new ArgumentNullException(nameof(expectedHash));

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var computed = pbkdf2.GetBytes(HashSize);
            return CryptographicOperations.FixedTimeEquals(computed, expectedHash);
        }
    }
}

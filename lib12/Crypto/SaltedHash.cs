using System;
using System.Security.Cryptography;

namespace lib12.Crypto
{
    /// <summary>
    /// Helps produce salted hash
    /// </summary>
    public static class SaltedHash
    {
        /// <summary>
        /// Generates random salt.
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            var saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
                provider.GetNonZeroBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Computes the hash.
        /// </summary>
        /// <param name="salt">The salt.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string ComputeHash(string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 1000))
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        }

        /// <summary>
        /// Verifies if hash matches salted password
        /// </summary>
        /// <param name="salt">The salt.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static bool Verify(string salt, string hash, string password)
        {
            return hash == ComputeHash(salt, password);
        }
    }
}
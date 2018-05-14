using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ESD6NL.DriverSystem.Helpers
{
    public class HashingHelper
    {
        public static string generatePasswordHash(string pwd, string salt)
        {
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: pwd, salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256, iterationCount: 10000, numBytesRequested: 256 / 8));
            return hash;
        }

        public static bool Validate(string value, string salt, string hash)
            => generatePasswordHash(value, salt) == hash;

        public static string getSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
    }
}
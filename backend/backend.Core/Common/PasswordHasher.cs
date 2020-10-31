using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace backend.Core.Common
{
    public static class PasswordHasher
    {
        private static byte[] salt = new byte[] { 62, 4, 14, 42, 12,44, 62, 0 };

        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
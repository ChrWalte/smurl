using System;
using System.Security.Cryptography;

namespace smurl.services.Shared
{
    public static class Utilities
    {


        public static string RandomSlug(int length)
        {
            var provider = new RNGCryptoServiceProvider();
            var slug = string.Empty;

            for (var i = 0; i < length; i++)
            {
                var bytes = new byte[length];
                provider.GetBytes(bytes);
                var randomNumber = BitConverter.ToInt32(bytes);
                var charIndex = Math.Abs(randomNumber) % ServicesConstants.AllowedSlugChars.Length;
                slug += ServicesConstants.AllowedSlugChars[charIndex];
            }

            return slug;
        }
    }
}

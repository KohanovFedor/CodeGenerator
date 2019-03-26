using System;

namespace CodeGenerator
{
    static internal class Base36
    {
        private const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Converts from base 36 to base 10.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>Value in base 10</returns>
        internal static int Decode(string value)
        {
            var decoded = 0;

            for (var i = 0; i < value.Length; ++i)
                decoded += (int)(Digits.IndexOf(value[i]) * Math.Pow(Digits.Length, value.Length - i - 1));

            return decoded;
        }

        /// <summary>
        /// Converts from base 10 to base 36.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>Value in base 36</returns>
        internal static string Encode(int value)
        {
            var encoded = string.Empty;

            do
                encoded = Digits[(value % Digits.Length)] + encoded;
            while ((value /= Digits.Length) != 0);

            return encoded;
        }

    }
}

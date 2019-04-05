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
            if (value == null)
                throw new ArgumentNullException("Строка не должна быть пустой");
            var decoded = 0;

            for (var i = 0; i < value.Length; ++i)
            {
                if (Digits.IndexOf(value[i]) != -1)
                    decoded += (int)(Digits.IndexOf(value[i]) * Math.Pow(Digits.Length, value.Length - i - 1));
                else
                    throw new FormatException($"В строке присутсвует недопустимый символ: {value[i]}");
            }

            return decoded;
        }

        /// <summary>
        /// Converts from base 10 to base 36. Оnly positive.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <returns>Value in base 36</returns>
        internal static string Encode(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Число должно быть положительным");

            var encoded = string.Empty;

            do
                encoded = Digits[value % Digits.Length] + encoded;
            while ((value /= Digits.Length) != 0);

            return encoded;
        }

    }
}

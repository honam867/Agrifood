using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AspNetCore.AutoGenerate
{
    public static class AutoGenerate
    {
        private static string GetRandomString(int length, IEnumerable<char> characterSet, bool isDigit, bool isSpecialChar)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            var result = new char[length];
            int digitIndex = 0;
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(bytes);
            }

            // generate only character
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            result[0] = (char)(result[0] - 32);
            // generate special character
            if (isSpecialChar)
            {
                int rand = new Random().Next(33, 48);
                result[(rand % (length - 1)) + 1] = (char)rand;
                digitIndex = (rand % (length - 1)) + 1;
            }

            // generate digit
            if (isDigit)
            {
                int rand = new Random().Next(48, 58);
                while ((rand % (length - 1)) + 1 == digitIndex)
                {
                    rand = new Random().Next(48, 58);
                }
                result[(rand % (length - 1)) + 1] = (char)rand;
            }

            return new string(result);
        }
        public static string GetRandomDigit(int length)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            var bytes = new byte[length * 8];
            var result = new char[length];
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(bytes);
            }

            int rand = new Random().Next(48, 58);
            int index = 0;
            while (index < length)
            {
                rand = new Random().Next(48, 58);
                result[index] = (char)rand;
                index++;
            }

            return new string(result);
        }

        public static string AutoGeneratePassword(int length, bool isDigit, bool isSpecialChar)
        {
            const string alphanumericCharacters = "abcdefghijklmnopqrstuvwxyz";
            return GetRandomString(length, alphanumericCharacters, isDigit, isSpecialChar);
        }

        public static string AutoGenerateUsername(string role, int number)
        {
            string suffix = ("00" + number.ToString());
            return role + suffix.Substring(suffix.Length - 3, 3);
        }

        public static string AutoGenerateCode(int length)
        {
            const string alphanumericCharacters = "abcdefghijklmnopqrstuvwxyz";
            return GetRandomString(length, alphanumericCharacters, false, false).ToUpper();
        }
    }
}

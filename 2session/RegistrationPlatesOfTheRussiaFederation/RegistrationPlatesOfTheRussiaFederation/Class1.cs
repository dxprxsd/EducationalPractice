using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegistrationPlatesOfTheRussiaFederation
{
    public class RegMarkLib
    {
        private static readonly string AllowedLetters = "ABEKMHOPCTYX";
        private static readonly int MinRegionCode = 1;
        private static readonly int MaxRegionCode = 199;

        public static bool CheckMark(string mark)
        {
            if (string.IsNullOrEmpty(mark)) return false;

            var regex = new Regex("^[ABEKMHOPCTYX][0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{2,3}$");
            if (!regex.IsMatch(mark)) return false;

            // Найдем индекс начала кода региона
            int regionStartIndex = mark.Length - 3; // Предполагаем, что регион состоит из 3 символов

            // Если последний символ не цифра, значит регион состоит из 2 символов
            if (!char.IsDigit(mark[regionStartIndex]))
            {
                regionStartIndex++;
            }

            // Парсим код региона
            int region = int.Parse(mark.Substring(regionStartIndex));

            return region >= MinRegionCode && region <= MaxRegionCode;
        }

        public static string GetNextMarkAfter(string mark)
        {
            if (!CheckMark(mark)) throw new ArgumentException("Invalid mark format");

            char letter1 = mark[0];
            int num = int.Parse(mark.Substring(1, 3));
            string letters = mark.Substring(4, 2);

            // Найдем индекс начала кода региона
            int regionStartIndex = mark.Length - 3; // Предполагаем, что регион состоит из 3 символов

            // Если последний символ не цифра, значит регион состоит из 2 символов
            if (!char.IsDigit(mark[regionStartIndex]))
            {
                regionStartIndex++;
            }

            // Парсим код региона
            int region = int.Parse(mark.Substring(regionStartIndex));

            if (num < 999)
            {
                return $"{letter1}{num + 1:D3}{letters}{region:D2}";
            }
            else
            {
                int letterIndex = AllowedLetters.IndexOf(letters[1]);
                if (letterIndex < AllowedLetters.Length - 1)
                {
                    return $"{letter1}000{letters[0]}{AllowedLetters[letterIndex + 1]}{region:D2}";
                }
                else
                {
                    return "Series exhausted";
                }
            }
        }

        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            if (!CheckMark(prevMark) || !CheckMark(rangeStart) || !CheckMark(rangeEnd))
                throw new ArgumentException("Invalid mark format");

            string nextMark = GetNextMarkAfter(prevMark);

            // Убеждаемся, что nextMark находится в пределах диапазона
            while (string.Compare(nextMark, rangeStart) < 0 || string.Compare(nextMark, rangeEnd) > 0)
            {
                nextMark = GetNextMarkAfter(nextMark);
                if (nextMark == "Series exhausted" || string.Compare(nextMark, rangeEnd) > 0)
                {
                    return "out of stock";
                }
            }

            return nextMark;
        }

        public static int GetCombinationsCountInRange(string mark1, string mark2)
        {
            if (!CheckMark(mark1) || !CheckMark(mark2)) throw new ArgumentException("Invalid mark format");

            int startNum = int.Parse(mark1.Substring(1, 3));
            int endNum = int.Parse(mark2.Substring(1, 3));

            return Math.Max(0, endNum - startNum + 1);
        }
    }
}


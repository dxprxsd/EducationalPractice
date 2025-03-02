using System;
using System.Text.RegularExpressions;

namespace RegistrationPlatesOfTheRussiaFederation
{
    /// <summary>
    /// Класс для работы с регистрационными знаками России.
    /// </summary>
    public class RegMarkLib
    {
        private static readonly string AllowedLetters = "ABEKMHOPCTYX";
        private static readonly int MinRegionCode = 1;
        private static readonly int MaxRegionCode = 199;

        /// <summary>
        /// Проверяет корректность формата регистрационного знака.
        /// </summary>
        /// <param name="mark">Регистрационный знак.</param>
        /// <returns>true, если формат верный, иначе false.</returns>
        public static bool CheckMark(string mark)
        {
            try
            {
                if (string.IsNullOrEmpty(mark)) return false;

                var regex = new Regex("^[ABEKMHOPCTYX][0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{2,3}$");
                if (!regex.IsMatch(mark)) return false;

                // Определяем индекс начала кода региона
                int regionStartIndex = mark.Length - 3;
                if (!char.IsDigit(mark[regionStartIndex]))
                {
                    regionStartIndex++;
                }
                int region = int.Parse(mark.Substring(regionStartIndex));
                return region >= MinRegionCode && region <= MaxRegionCode;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Получает следующий регистрационный знак после заданного.
        /// </summary>
        /// <param name="mark">Текущий регистрационный знак.</param>
        /// <returns>Следующий регистрационный знак или сообщение об ошибке.</returns>
        public static string GetNextMarkAfter(string mark)
        {
            try
            {
                if (!CheckMark(mark)) throw new ArgumentException("Invalid mark format");

                char letter1 = mark[0];
                int num = int.Parse(mark.Substring(1, 3));
                string letters = mark.Substring(4, 2);

                int regionStartIndex = mark.Length - 3;
                if (!char.IsDigit(mark[regionStartIndex]))
                {
                    regionStartIndex++;
                }
                int region = int.Parse(mark.Substring(regionStartIndex));

                // Увеличиваем число, если оно не достигло максимального значения
                if (num < 999)
                {
                    return $"{letter1}{num + 1:D3}{letters}{region:D2}";
                }
                else
                {
                    // Если число достигло 999, меняем буквы
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
            catch
            {
                return "Error processing input";
            }
        }

        /// <summary>
        /// Получает следующий регистрационный знак в заданном диапазоне.
        /// </summary>
        /// <param name="prevMark">Предыдущий регистрационный знак.</param>
        /// <param name="rangeStart">Начало диапазона.</param>
        /// <param name="rangeEnd">Конец диапазона.</param>
        /// <returns>Следующий знак в диапазоне или сообщение "out of stock".</returns>
        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            try
            {
                if (!CheckMark(prevMark) || !CheckMark(rangeStart) || !CheckMark(rangeEnd))
                    throw new ArgumentException("Invalid mark format");

                string nextMark = GetNextMarkAfter(prevMark);
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
            catch
            {
                return "Error processing input";
            }
        }

        /// <summary>
        /// Вычисляет количество возможных комбинаций в заданном диапазоне.
        /// </summary>
        /// <param name="mark1">Начальный знак диапазона.</param>
        /// <param name="mark2">Конечный знак диапазона.</param>
        /// <returns>Количество возможных комбинаций или -1 в случае ошибки.</returns>
        public static int GetCombinationsCountInRange(string mark1, string mark2)
        {
            try
            {
                if (!CheckMark(mark1) || !CheckMark(mark2)) throw new ArgumentException("Invalid mark format");

                int startNum = int.Parse(mark1.Substring(1, 3));
                int endNum = int.Parse(mark2.Substring(1, 3));
                return Math.Max(0, endNum - startNum + 1);
            }
            catch
            {
                return -1;
            }
        }
    }
}

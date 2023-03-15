using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace MyToDouble
{
    public static class Ext
    {
        // Длина не превышает 15 знаков.
        // Если введены не корректные данные возврат 0.
        // Обрабатывается как с "." так и с ",".
        // Проверка на случайно введенные несколько разделителей.


        /// <summary>
        /// Метод расширения перевода строки в double.
        /// </summary>
        /// <param name="e">string</param>
        /// <returns>double</returns>
        public static double MyToDouble(this string e)
        {
            //string s = "74654576,457991"; // Для теста.

            string s = e;

            if (s == "")
                return 0;

            if (s.Length > 15)
                return 0;

            Regex regex = new Regex("[{0123456789,\\.}]");

            MatchCollection matches = regex.Matches(s);

            // Присутствуют либо цифры,  либо "." либо ",".
            if (matches.Count == s.Length)
            {
                double integralPart = 10;
                double decimalPart = 0.1;

                bool isIntegralPart = true;

                Regex regexComma = new Regex("[{,}]");
                MatchCollection matchesComma = regexComma.Matches(s);

                Regex regexPoint = new Regex("[{\\.}]");
                MatchCollection matchesPoint = regexPoint.Matches(s);

                // Есть либо "." либо ",".
                if ((matchesComma.Count <= 1 && matchesPoint.Count == 0) || (matchesComma.Count == 0 && matchesPoint.Count <= 1))
                {
                    double d = 0;

                    foreach (char c in s)
                    {
                        if (c == '.' || c == ',')
                        {
                            isIntegralPart = false;
                            continue;
                        }

                        if (isIntegralPart)
                        {
                            d = d * integralPart + char.GetNumericValue(c);
                        }
                        else
                        {
                            d = d + (char.GetNumericValue(c) * decimalPart);
                            decimalPart *= 0.1;
                        }
                    }
                    return d;
                }
                else
                    return 0;
            }
            return 0;

        }
    }
}

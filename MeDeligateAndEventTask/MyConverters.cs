using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDeligateAndEventTask
{
    /// <summary>
    /// Сборник конвертеров из любого типа в double
    /// </summary>
    public static class MyConverters
    {
        /// <summary>
        /// Конвертер из int в double
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double ConvertIntToDouble(int num)
        {
            return Convert.ToDouble(num);
        }

        /// <summary>
        /// Конвертер из string в double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ConvertStringToDouble(string str)
        {
            return double.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}

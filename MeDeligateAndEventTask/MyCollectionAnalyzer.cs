using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeDeligateAndEventTask
{
    public static class MyCollectionAnalyzer
    {
        public static T GetMax<T> (this IEnumerable<T> collection, Func<T, double> convertToNumber)
        {
			// Итерация для Count() не должна производиться, коллекция не была "усложнена" (https://stackoverflow.com/a/2521614)
			if (collection.Count() == 0)
            {
                throw new ArgumentException("В коллекции нет ни одного элемента");
            }

            var maxValue = double.MinValue;
            // Убираем лишнюю итерацию инициализируя переменную значением по умолчанию для полученного типа
            T? maxItem = default;

            foreach (var item in collection)
            {
                var currentNum = convertToNumber(item);
                if (currentNum > maxValue)
                {
                    maxValue = currentNum;
                    maxItem = item;
                }
            }

			return maxItem;
		}
    }
}

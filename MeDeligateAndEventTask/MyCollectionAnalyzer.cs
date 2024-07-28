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
            if (!collection.Any())
            {
                throw new ArgumentException("В коллекции нет ни одного элемента");
            }

            var maxValue = double.MinValue;
            T maxItem = collection.First();

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

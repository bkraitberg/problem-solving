using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_solving
{
    public static class Extensions
    {
        public static bool isOdd(this int i)
        {
            return i % 2 != 0;
        }

        public static Dictionary<T, int> makeCountDictionary<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new NullReferenceException(); // Boo

            return source
                .GroupBy(item => item)
                .ToDictionary(entry => entry.Key, entry => entry.Count());
        }

        public static String toFizzBuzz(this int i)
        {
            String replacement = "";
            if (i % 3 == 0)
                replacement = "Fizz";
            if (i % 5 == 0)
                replacement += "Buzz";
            return String.IsNullOrEmpty(replacement) ? i.ToString() : replacement;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace problem_solving
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            return arr.Sum(i => (long)i);
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            return SumArray(arr.Where(i => i.isOdd()));
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            return SumArray(arr.Where((i, index) => index.isOdd()));
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA.Intersect(arrB);
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA
                .Union(arrB)
                .Except(GetArrayIntersect(arrA, arrB));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            HashSet<long> seen = new HashSet<long>();

            foreach (var currValue in arr)
            {
                if (seen.Contains(target - currValue))
                    return true;

                seen.Add(currValue);
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            if (arr == null)
                throw new ArgumentNullException(); // Boo
            return SumArray(arr.makeCountDictionary().Where(entry => entry.Value == 1).Select(entry => entry.Key));
//            return SumArray(arr.Where(i => arr.Count(v => v == i) == 1));
        }

        public static String DoubleString(String s)
        {
            return String.Concat(s.Select(c => new String(c, 2)));
        }

        public static int CountChars(String s, char c)
        {
            return s.Count(k => k == c);
        }

        public static long SumDigits(String s)
        {
            return SumArray(s.Where(c => Char.IsDigit(c)).Select(c => (int)Char.GetNumericValue(c)));
        }

        public static long SumNumbers(String s)
        {
            return SumArray(Regex.Matches(s, "[0-9]+").Cast<Match>().Select(m => int.Parse(m.Value)));
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            return s1.makeCountDictionary().OrderBy(c => c.Key).SequenceEqual(s2.makeCountDictionary().OrderBy(c => c.Key));
        }

        public static int BlackJack(int count1, int count2)
        {
            return NPlayerBlackJack(new int[] { count1, count2 });
            //return count1 > 21
            //    ? count2 > 21 ? 0 : count2
            //    : count2 > 21 ? count1 : Math.Max(count1, count2);
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            return NPlayerBlackJack(new int[] { count1, count2, count3, count4, count5 });
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            return counts.Concat(new int[] {0}).Where(c => c <= 21).Max();
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            return arr.makeCountDictionary();
        }

        public static int Factorial(int n)
        {
            return n > 1 ? (n * Factorial(n - 1)) : 1;
        }

        public static List<String> FB(int n)
        {
            return Enumerable.Range(1, n).Select(i => i.toFizzBuzz()).ToList();
        }
    }
}

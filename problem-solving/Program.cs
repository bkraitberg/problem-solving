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
        private const int BlackjackLimit = 21;

        static void Main(string[] args)
        {
        }

        private static void ThrowExceptionIfNull(object arr, bool throwNullReferenceInstead = false)
        {
            if (arr == null)
            {
                if (throwNullReferenceInstead)
                {
                    throw new NullReferenceException();
                }

                throw new ArgumentNullException();
            }
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            ThrowExceptionIfNull(arr);

            return Array.ConvertAll(arr.ToArray(), i => (long)i).Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            ThrowExceptionIfNull(arr);

            return arr.Sum(v => (v % 2 == 0) ? 0 : v);
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            ThrowExceptionIfNull(arr);

            return arr.Select((value, index) => new { value, index }).Sum(x => (x.index % 2 == 1) ? x.value : 0);
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            ThrowExceptionIfNull(arr);

            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            ThrowExceptionIfNull(arrA);
            ThrowExceptionIfNull(arrB);

            return arrA.Intersect(arrB);

        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            ThrowExceptionIfNull(arrA);
            ThrowExceptionIfNull(arrB);

            var nonIntersectingValues = new List<int>();

            foreach (var valueA in arrA)
            {
                if (!arrB.Contains(valueA))
                {
                    nonIntersectingValues.Add(valueA);
                }
            }

            foreach (var valueB in arrB)
            {
                if (!arrA.Contains(valueB))
                {
                        nonIntersectingValues.Add(valueB);
                }
            }

            return nonIntersectingValues;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            ThrowExceptionIfNull(arr, true);

            //var arr.Select((value, index) => new { value, index })

            var array = arr.ToArray();

            for (int i = 0; i < array.Count(); i++)
            {
                var element1 = array[i];

                for (int j = 0; j < array.Count(); j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var element2 = array[j];

                    if (element1 + element2 == target)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            ThrowExceptionIfNull(arr);

            return arr.Where(x => arr.Count(c => c == x) == 1).Sum();
        }

        public static String DoubleString(String s)
        {
            ThrowExceptionIfNull(s);

            string doubledString = "";

            foreach (var c in s)
            {
                doubledString += c.ToString() + c.ToString(); 
            }

            return doubledString;
        }

        public static int CountChars(String s, char c)
        {
            ThrowExceptionIfNull(s);

            return s.Count(l => l == c);
        }

        public static long SumDigits(String s)
        {
            ThrowExceptionIfNull(s);

            return s.Sum(c => Char.IsNumber(c) ? int.Parse(c.ToString()) : 0);
        }

        public static long SumNumbers(String s)
        {
            ThrowExceptionIfNull(s);

            var numbersToAdd = new List<int>();
            var currentNumberString = string.Empty;

            foreach (var c in s)
            {
                if (Char.IsNumber(c))
                {
                    currentNumberString += c.ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentNumberString))
                    {
                        numbersToAdd.Add(int.Parse(currentNumberString));
                        currentNumberString = string.Empty;
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentNumberString))
            {
                numbersToAdd.Add(int.Parse(currentNumberString));
            }

            return numbersToAdd.Sum();
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            foreach (var c in s1)
            {
                var characterIndex = s2.IndexOf(c);

                if (characterIndex == -1)
                {
                    return false;
                }
                
                s2 = RemoveIndex(s2, characterIndex);
            }

            return (s2.Length == 0);
        }

        private static string RemoveIndex(string s, int index)
        {
            var firstPartOfString = s.Substring(0, index);

            if (index + 1 == s.Length)
            {
                return firstPartOfString;
            }

            var lastPartOfString = s.Substring(index + 1);

            return firstPartOfString + lastPartOfString;
        }

        public static int BlackJack(int count1, int count2)
        {
            if (count1 > BlackjackLimit && count2 > BlackjackLimit)
            {
                return 0;
            }

            if (count1 > BlackjackLimit)
            {
                return count2;
            }

            if (count2 > BlackjackLimit)
            {
                return count1;
            }

            return Math.Max(count1, count2);
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            var numbers = new List<int>();;

            if (count1 <= BlackjackLimit)
            {
                numbers.Add(count1);
            }

            if (count2 <= BlackjackLimit)
            {
                numbers.Add(count2);
            }

            if (count3 <= BlackjackLimit)
            {
                numbers.Add(count3);
            }

            if (count4 <= BlackjackLimit)
            {
                numbers.Add(count4);
            }

            if (count5 <= BlackjackLimit)
            {
                numbers.Add(count5);
            }

            if (numbers.Count == 0)
            {
                return 0;
            }

            return numbers.Max();
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            var validCounts = counts.Where(n => n <= 21);

            if (validCounts.Count() == 0)
            {
                return 0;
            }

            return validCounts.Max();
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            var dictionary = new Dictionary<String, int>();

            foreach (var word in arr)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word] += 1;
                }
            }
            
            return dictionary;
        }

        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            var factorial = n;

            for (int i = n - 1; i >= 1; i--)
            {
                factorial *= i;
            }
            
            return factorial;
        }

        public static List<String> FB(int n)
        {
            var listOfStrings = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                var divisibleBy3 = (i % 3 == 0);
                var divisibleBy5 = (i % 5 == 0);

                if (divisibleBy3 && divisibleBy5)
                {
                    listOfStrings.Add("FizzBuzz");
                }
                else if (divisibleBy3)
                {
                    listOfStrings.Add("Fizz");
                }
                else if (divisibleBy5)
                {
                    listOfStrings.Add("Buzz");
                }
                else
                {
                    listOfStrings.Add(i.ToString());
                }
            }

            return listOfStrings;
        }
    }
}

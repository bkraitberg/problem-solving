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
            // return the sum of all the values in the array
            return arr.Sum(a => (long)a);
            //return arr.Sum(a => Convert.ToInt64(a));
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            return arr.Where(a => a % 2 != 0).Sum(a => (long)a);
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            return arr.Where((a, i) => i % 2 != 0).Sum(a => (long)a);
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            return arrA.Intersect(arrB);
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            return arrA.Union(arrB).Except(arrA.Intersect(arrB));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            var list = new HashSet<long>();
            foreach (var value in arr)
            {
                long complement = target - value;
                if (list.Contains(complement))
                {
                    return true;
                }

                list.Add(value);
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            return arr.GroupBy(a => a).Where(g => g.Count() == 1).Select(g => g.Key).Sum();

            //return (from a in arr
            //        group a by a into g
            //        where g.Count() == 1
            //        select g.Key).Sum();

        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            return s.Select(c => c.ToString()).Aggregate(String.Empty, (a, c) => String.Format("{0}{1}{1}", a, c));
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            // return s.Where(ch => ch == c).Count();
            return s.Count(ch => ch == c );
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            return s.Where(c => Char.IsDigit(c)).Sum(c => (long)Char.GetNumericValue(c));
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            string[] numbers = Regex.Split(s, "[^\\d]");
            return numbers.Where(n => !String.IsNullOrEmpty(n)).Sum(n => Convert.ToInt32(n));
         }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            try
            {
                var sorted1 = s1.OrderBy(c => c);
                var sorted2 = s2.OrderBy(c => c);
                return sorted1.SequenceEqual(sorted2);
            }
            catch (ArgumentNullException)
            {
                throw new NullReferenceException();
            }
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            var counts = new List<int> { count1, count2 };
            return counts.Where(c => c < 22).DefaultIfEmpty(0).Max();
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            var counts = new List<int> { count1, count2, count3, count4, count5 };
            return counts.Where(c => c < 22).DefaultIfEmpty(0).Max();
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return counts.Where(c => c < 22).DefaultIfEmpty(0).Max();
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            //var dictionary = new Dictionary<String, int>();
            //foreach (var word in arr)
            //{
            //    if (dictionary.ContainsKey(word))
            //    {
            //        dictionary[word] += 1;
            //    }
            //    else
            //    {
            //        dictionary.Add(word, 1);
            //    }
            //}

            //return dictionary;

            if (arr == null)
            {
                throw new NullReferenceException();
            }

            var x = from word in arr
                    group word by word into g
                    select new
                    {
                        Key = g.Key,
                        Value = g.Count()
                    };
            return x.ToDictionary(d => d.Key, d => d.Value );

            //return arr
            //    .GroupBy(word => word)
            //    .Select(g => new { Key = g.Key, Value = g.Count() })
            //    .ToDictionary(d => d.Key, d => d.Value);
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            return n == 0 ? 1 : n * Factorial(n - 1);
            
            //return n == 0 ? 1 : Enumerable.Range(1, n).Aggregate((result, value) => result * value);
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            return Enumerable.Range(1, n).Select(num =>
                (num % 15 == 0) ? "FizzBuzz" :
                (num % 5 == 0) ? "Buzz" :
                (num % 3 == 0) ? "Fizz" :
                num.ToString()).ToList();
        }
    }
}

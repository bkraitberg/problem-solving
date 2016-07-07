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

        private static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        private static bool IsOdd(int i)
        {
            return !IsEven(i);
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("ar");
            }

            // return the sum of all the values in the array

            //x return arr.Sum();
            //x return arr.Aggregate((sum, i) => unchecked(sum + i));

            long result = 0;

            foreach (int a in arr)
            {
                result += a;
            }

            return result;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            return arr.Sum(a => IsOdd(a) ? a : 0);
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            return arr.Where((a, i) => IsOdd(i)).Sum();
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
            if (arr == null)
            {
                throw new NullReferenceException("arr");
            }

            // return true if any 2 values in the array have a sum equal to the target value
            for (int i = 0; i < arr.Count(); i++)
            {
                for (int j = 0; j < arr.Count(); j++)
                {
                    if (i != j && arr.ElementAt(i) + arr.ElementAt(j) == target)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            return arr.GroupBy(x => x)
                  .Where(g => g.Count() < 2)
                  .Select(g => g.Key)
                  .Sum();
        }

        public static String DoubleString(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            String result = "";

            for (int i = 0; i < s.Length; i++)
            {
                result = result + s[i] + s[i];
            }

            return result;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            return s.AsEnumerable().Count(x => x == c);
        }

        public static long SumDigits(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            return s.ToCharArray().Where(x => x >= '0' && x <= '9').Select(a => a - '0').Sum();
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            s = Regex.Replace(s, "[^0-9]", " ");
            String[] arr = s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            return arr.Select(x => Int32.Parse(x)).Sum();
        }

        private static Boolean IsFirstAnagramOfSecond(String s1, String s2)
        {
            foreach (char c in s1)
            {
                if (s2.Count(x => x == c) != s1.Count(x => x == c))
                    return false;
            }

            return true;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            return IsFirstAnagramOfSecond(s1, s2) && IsFirstAnagramOfSecond(s2, s1);
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            return NPlayerBlackJack(new int[] { count1, count2 });
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return NPlayerBlackJack(new int[] { count1, count2, count3, count4, count5 });
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            if (counts.All(x => x > 21))
            {
                return 0;
            }

            return counts.Where(x => x <= 21).Max();
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException("arr");
            }

            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            return arr.Distinct().ToDictionary(x => x, x => arr.Count(y => y == x));
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            int result = 1;

            for (int i = n; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            List<String> result = new List<String>();

            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(Convert.ToString(i));
                }
            }

            return result;
        }
    }
}

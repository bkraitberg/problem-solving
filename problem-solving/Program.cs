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
            return arr.Sum(i => (long)i);
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            return arr.Where(value => value % 2 != 0).Sum(value => (long)value);
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            return arr.Where((value, index) => index % 2 == 1).Sum(value => (long)value);
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
            return arrA.Where(v => !arrB.Contains(v)).Union(arrB.Where(v => !arrA.Contains(v)));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            // return true if any 2 values in the array have a sum equal to the target value
            // TODO
            var arrWithIndex = arr.Select((x, index) => new { val = x, ind = index });
            return arrWithIndex.Any(val => arrWithIndex.Where(x => val.ind != x.ind).Any(val2 => val.val + val2.val == target));
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            return arr.Where(i => arr.Count(value => value == i ? true : false) == 1).Sum(value => (long)value);
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            if (null == s)
            {
                throw new ArgumentNullException();
            }

            if (String.Empty == s)
            {
                return String.Empty;
            }
            return s.ToCharArray().Select<char, String>(ch => new String(ch, 2)).Aggregate((i,j) => i + j);
        }

        public static int CountChars(String s, char c)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            // return the count of how many times char c occurs in string s
            return s.ToCharArray().Where(ch => c == ch).Count();
        }

        public static long SumDigits(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            return s.ToCharArray().Where(ch => Char.IsDigit(ch)).Sum(value => (long)int.Parse(value.ToString()));
        }

        public static long SumNumbers(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            if (s.Length == 0)
            {
                return 0;
            }

            String strOnlyDigitsAndSpaces = s.ToCharArray()
                .Select(ch => Char.IsDigit(ch) ? ch : ' ')
                .Select(ch => new String(ch,1))
                .Aggregate((str, ch) => str + "" + ch);

            return strOnlyDigitsAndSpaces
                .Split(null)
                .Where(str => str.Length > 0)
                .Select(str => int.Parse(str))
                .Sum(value => (long)value);
                
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            return s1.ToCharArray().OrderBy(ch => ch).SequenceEqual(s2.ToCharArray().OrderBy(ch => ch));
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            int[] cards = new int[] { count1, count2, 0 };
            var notOver = cards.Where(v => v <= 21).OrderByDescending(c => c);
            return notOver.First();
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            int[] cards = new int[] { count1, count2, count3, count4, count5, 0 };
            var notOver = cards.Where(v => v <= 21).OrderByDescending(c => c);
            return notOver.First();
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            var notOver = counts.Union(new int[]{0}).Where(v => v <= 21).OrderByDescending(c => c);
            return notOver.First();
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            return arr.Distinct().ToDictionary<string, string, int>(str => str, y => arr.Count(str => str == y));
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            return Enumerable.Range(1, n).Aggregate(1, (x,y) => y * x);
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            return Enumerable.Range(1, n)
                .Select(num => 
                    (num % 3 == 0 && num % 5 == 0) ? "FizzBuzz" 
                    : num % 5 == 0 ? "Buzz" 
                    : num % 3 == 0 ? "Fizz" 
                    : num.ToString())
                    .ToList(); 
           
        }
    }
}

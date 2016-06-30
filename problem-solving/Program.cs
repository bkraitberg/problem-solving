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
            return arr.Select(i => (long)i)
                .Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            return arr.Select(i => (long)i)
                .Where(x => x % 2 != 0)
                .Sum();
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            return arr.Select(i => (long)i)                
                .Select((v, i) => i % 2 == 0 ? 0 : v)
                .Sum();
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
            return arrA.Where(i => !arrB.Contains(i)).Union(arrB.Where(i => !arrA.Contains(i)));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            if (arr == null)
            {
                throw new NullReferenceException();
            }

            var a1 = arr.Select((v, i) => new { val = v, idx = i });
            var a2 = arr.Select((v, i) => new { val = v, idx = i });

            return a1.Any(a1Val => a2.Any(a2Val => a1Val.val + a2Val.val == target && a1Val.idx != a2Val.idx));
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            return arr.Select(i => (long)i)
                .GroupBy(v => v)
                .Select(g => new
                {
                    val = g.Key,
                    count = g.Count()
                })
                .Where(g => g.count == 1)
                .Sum(g => g.val);
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            return new String(s.ToArray()
                .Select(c => new[] { c, c })
                .SelectMany(i => i)
                .ToArray()
            );                
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            return s.ToArray().Count(sc => sc == c);
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            return s.ToArray()
                .Where(c => Char.IsDigit(c))
                .Select(c => Int64.Parse(c.ToString()))
                .Sum();
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            String onlyDigits = String.Join("", s.ToArray().Select(c => Char.IsDigit(c) ? c.ToString() : " "));
            return onlyDigits.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(v => Int64.Parse(v))
                .Sum();
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            if (s1 == null || s2 == null)
            {
                throw new NullReferenceException();
            }

            return s1.ToArray().OrderBy(c => c).SequenceEqual(s2.ToArray().OrderBy(c => c));
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            return new[] { count1, count2, 0 }
                .Select(v => new { diff = 21 - v, orig = v })
                .Where(var => var.diff >= 0)
                .OrderBy(v => v.diff)
                .First().orig;                
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return new[] { count1, count2, count3, count4, count5, 0 }
                .Select(v => new { diff = 21 - v, orig = v })
                .Where(var => var.diff >= 0)
                .OrderBy(v => v.diff)
                .First().orig;  
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return counts.Union(new[] { 0 })
                .Select(v => new { diff = 21 - v, orig = v })
                .Where(var => var.diff >= 0)
                .OrderBy(v => v.diff)
                .First().orig;  
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            if (arr == null)
            {
                throw new NullReferenceException();
            }

            return arr.GroupBy(v => v)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            return n == 0 ? 1 : Enumerable.Range(1, n)
                .Aggregate((acc, i) => acc * i);
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            return Enumerable.Range(1, n)
                .Select(i =>
                {
                    if (i % 3 == 0 && i % 5 == 0) return "FizzBuzz";
                    else if (i % 3 == 0) return "Fizz";
                    else if (i % 5 == 0) return "Buzz";
                    else return i.ToString();
                })
                .ToList();
        }
    }
}

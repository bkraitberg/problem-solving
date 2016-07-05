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
            //GetUniqueValues(new int[] { 1, 1 });
            //LoneSum(new int[] { 1, 2 });
            //HasSum(null, null);
            // DoubleString("ABC");
            //CountChars("ABC", 'A');
            //SumDigits("123A");
            // SumNumbers("12A3");
            //IsAnagram("", "");
            //NPlayerBlackJack(new[] { 1, 3, 6, 20, 33, 22, 14 });
            //WordCount(new[] { "Alex", "Alex", "Tony", "Masha" });

            //BlackJack(1, int.MaxValue);
            //FB(1);
            //GetArrayNotIntersect(new int[] { 1, 2 }, new int[] { 3, 4 });
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array
            // TODO
            return arr.Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            // TODO
            return arr.Where((item, index) => index % 2 != 0).Sum();
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            // TODO
            return arr.Where((item, index) => index % 2 == 0).Sum();
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            // TODO
            return arr.Concat(new[] { arr.Sum() });
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            // TODO
            return arrA.Intersect(arrB);
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            // TODO
            var intersect = arrA.Intersect(arrB);
            IEnumerable<int> output = Enumerable.Empty<int>();
            foreach (var item in arrA.Concat(arrB))
            {
                if (!intersect.Contains(item))
                    output = output.Concat(new[] { item });
            }

            return output;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            // TODO
            if (arr.Count() == 1) return false;
            var hash = arr.ToDictionary(x => x, x => 1);
            foreach (var k in hash.Keys)
                if (hash.ContainsKey(int.Parse((target - k).ToString()))) return true;

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            return arr.Distinct().Sum();
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"

            if (s == "") return string.Empty;

            string output = null;


            foreach (var item in s.ToArray())
            {
                output += item;
                output += item;
            }

            return output;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            return s.ToList().Select(x => x == c).Count(x => x == true);
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6            

            return s.Select(x => int.Parse(x.ToString())).Where(x => Regex.IsMatch(x.ToString(), @"^\d+$")).Sum(); ;
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            return Regex.Replace(s, "[^0-9]", " ").Split(' ').Sum(x => int.Parse(x));
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat

            if (s1 == null || s2 == null) throw new NullReferenceException("At least one of the params is null");

            return String.Join("", s1.Reverse()).Equals(s2);
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.

            const int TWENTYONE = 21;

            if (count1 > TWENTYONE && count2 > TWENTYONE) return 0;
            if (count1 > TWENTYONE && count2 <= TWENTYONE) return count2;
            if (count2 > TWENTYONE && count1 <= TWENTYONE) return count1;

            return Math.Abs(TWENTYONE - count1) > Math.Abs(TWENTYONE - count2) ? count2 : count1;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.

            return NPlayerBlackJack(new[] { count1, count2, count3, count4, count5 });
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.

            if (counts.Count() == 1) return counts.ToArray()[0];
            if (counts.Count() == 2) return BlackJack(counts.ToArray()[0], counts.ToArray()[1]);

            return BlackJack(counts.ToArray()[0], NPlayerBlackJack(counts.Skip(1)));
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array

            var hash = new Dictionary<string, int>(); // arr.ToDictionary(x => x, x => x.Count());

            foreach (var item in arr)
                hash[item] = arr.Select(x => x.Equals(item)).Count(x => x == true);

            return hash;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1

            if (n == 0) return 1;

            IEnumerable<int> ints = Enumerable.Range(1, n);
            return ints.Aggregate((f, s) => f * s);
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"

            var list = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    list.Add("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    list.Add("Buzz");
                }
                else if (i % 3 == 0)
                {
                    list.Add("Fizz");
                }
                else
                {
                    list.Add(i.ToString());
                }
            }

            return list;
        }
    }
}

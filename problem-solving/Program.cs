using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

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
            return arr.Sum(a => Convert.ToInt64(a, CultureInfo.InvariantCulture));
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            return arr.Where(a => (a%2 != 0)).Sum();
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            return arr.Where((a, index) => (index + 1) %2 == 0).Sum();
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            return arrA.Where(a => arrB.Contains(a)).Distinct();
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            return arrA.Where(a => !arrB.Contains(a)).Concat(
                   arrB.Where(b => !arrA.Contains(b))).Distinct();
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            if (arr == null || target == null)
                throw new NullReferenceException();

            for(int i=0; i < arr.Count(); i++)
            {
                var tempArr = arr.ToList();

                int currVal = tempArr[i];
                tempArr.RemoveAt(i);

                int diff = (int)target - currVal;

                if (tempArr.Contains(diff))
                    return true;
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            return arr.Aggregate(0,(total, next) => arr.Count(a => a == next) > 1 ? total : total + next);
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            if (s == null)
                throw new ArgumentNullException();

            int i = 1;
            foreach (char c in s)
            {
                s = s.Insert(i + (i-1), c.ToString());
                i++;
            }

            return s;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            return s.Count(character => character == c);
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            if (s == null)
                throw new ArgumentNullException();

            long total = 0;

            foreach (char c in s)
            {
                try
                {
                    total += Convert.ToInt32(c.ToString(), CultureInfo.InvariantCulture);
                }
                catch (System.FormatException){}
            }

            return total;
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            if (s == null)
                throw new ArgumentNullException();

            // *** THIS REGEX SPLIT HAS A PROBLEM WITH ESCAPE CHARACTERS ***
            String[] strings = Regex.Split(s, @"\D+");
            strings = strings.Where(str => !String.IsNullOrEmpty(str)).ToArray();

            return strings.Sum(str => Convert.ToInt32(str, CultureInfo.InvariantCulture));
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            if (s1 == null || s2 == null)
                throw new NullReferenceException();

            List<char> s1List = s1.ToList();
            List<char> s2List = s2.ToList();

            foreach (char c in s1List)
            {
                int loc = s2List.FindIndex(c2 => c2 == c);

                if (loc == -1) return false;

                s2List.RemoveAt(loc);
            }

            if (s2List.Count == 0) return true;

            return false;
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            if (count1 <= 21)
            {
                if (count2 > 21)
                    return count1;

                return (Math.Max(count1, count2));
            }
            else if (count2 <= 21)
            {
                return count2;
            }

            return 0;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            List<int> counts = new List<int>(){count1,count2,count3,count4,count5};
            IEnumerable<int> didntBust = counts.Where(c => c <= 21);
            if (didntBust.Any())
                return didntBust.Max();

            return 0;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.

            IEnumerable<int> didntBust = counts.Where(c => c <= 21);
            if (didntBust.Any())
                return didntBust.Max();

            return 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array

            if (arr == null)
                throw new NullReferenceException();

            bool contin = true;
            Dictionary<String, int> dictionary = new Dictionary<String, int>();
            List<String> array = arr.ToList();

            while (array.Count > 0)
            {
                String next = array.First();
                int nMatch = array.Count(a => a == next);
                array.RemoveAll(a => a == next);
                dictionary.Add(next, nMatch);
            }

            return dictionary;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            if (n == 0) return 1;
            
            for (int i = n; i > 1; i--)
            {
                n *= (i - 1);
            }

            return n;
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            List<String> strings = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if (i%3 == 0 && i%5 == 0)
                    strings.Add("FizzBuzz");
                else if (i%3 == 0)
                    strings.Add("Fizz");
                else if (i%5 == 0)
                    strings.Add("Buzz");
                else strings.Add(i.ToString());
            }

            return strings;
        }
    }
}

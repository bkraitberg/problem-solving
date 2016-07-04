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
            // TODO
            long sum = 0;
            foreach (int val in arr)
            {
                sum += val;
            }

            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            // TODO
            long sum = 0;
            foreach (int val in arr)
            {
                if ((val % 2) != 0)
                {
                    sum += val;
                }
            }

            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            // TODO
            long sum = 0;
            int index = 1;

            foreach (int val in arr)
            {
                if ((index % 2) == 0)
                {
                    sum += val;
                }
                index = index + 1;
            }

            return sum;

        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            // TODO

            return arr.Distinct();
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
            return GetArrayNotIntersect(arrA, arrB);
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            // TODO

            foreach (int val1 in arr)
            {
                foreach (int val2 in arr)
                {
                    if (val1 + val2 == target)
                        return true;

                }
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            IEnumerable<int> arr2 = arr.Distinct();
            long sum = 0;
            foreach (int val in arr2)
            {
                sum += val;
            }
            return sum;
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            String result = null;
            foreach (char ch in s)
            {
                result = ch + "" + ch;
            }
            return result;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            int count = 0;
            foreach (char ch in s)
            {
                if (ch == c)
                {
                    count++;
                }

            }
            return count;
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            int count = 0;
            long sum = 0;
            foreach (char ch in s)
            {
                if (char.IsDigit(ch))
                {
                    sum += (long)char.GetNumericValue(ch);
                }

            }
            return sum;
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33

            return 0;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            if (s1.Reverse() == s2)
                return true;
            else
                return false;
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            return 0;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return 0;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            return null;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            if (n == 1) return 1;
            else return n * Factorial(n - 1);
            
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"

            for(int i; i<n; i++)
            {
            if (i % 3 == 0 && i % 5 == 0) System "FizzBuzz";
            if (i % 3 == 0) return "Fizz";
            if (i % 5 == 0) return "Buzz";
            }
        }
    }
}

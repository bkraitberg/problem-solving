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

		public static void NullCheck(Object arr)
		{
			if (arr == null)
				throw new ArgumentNullException("arr");
		}

        public static long SumArray(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array

			NullCheck(arr);

			long sum = 0;
			foreach (var item in arr)
			{
				sum += item;
			}
			return sum;

			
			//return arr.Sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
			NullCheck(arr);
			long sum = 0;
			foreach (var item in arr)
			{
				if (item % 2 == 1)
				{
					sum += item;
				}
			}
			return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
			NullCheck(arr);
			long sum = 0;
			for (int i = 1; i < arr.Count(); i += 2)
			{
				sum += arr.ToArray()[i];
			}
            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
			NullCheck(arr);


            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
			NullCheck(arrA);
			NullCheck(arrB);

			return arrA.Intersect(arrB);
        }

		class NotInteresectCompare : IEqualityComparer<int>
		{
			public bool Equals(int x, int y)
			{
				return x != y;
			}
			public int GetHashCode(int codeh)
			{
				return codeh.GetHashCode();
			}
		}

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
			NullCheck(arrA);
			NullCheck(arrB);

			return arrA.Intersect(arrB, new NotInteresectCompare());
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value


			return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
			NullCheck(arr);
            return arr.Distinct().Sum();
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
			NullCheck(s);
			string output = "";
			foreach (var item in s)
			{
				output += item.ToString() + item.ToString();
			}
			return output;
        }

        public static int CountChars(String s, char c)
        {

            // return the count of how many times char c occurs in string s
			int output = 0;
			foreach (char item in s)
			{
				if (item == c)
					output++;
			}
            return output;
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
			long output = 0;
			foreach (char item in s)
			{
				if (char.IsNumber(item))
				{
					output += int.Parse(item.ToString());
				}
			}
			return output;
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
			NullCheck(counts);
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            return 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
			NullCheck(arr);
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            return null;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            return 0;
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            return null;
        }
    }
}

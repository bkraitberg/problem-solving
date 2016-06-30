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
            long sum = 0;

            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            foreach (int arrInt in arr)
            {
                sum += arrInt;
            }

            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            long sum = 0;

            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            foreach (int arrInt in arr)
            {
                if (arrInt % 2 != 0)
                {
                    sum += arrInt;
                }
            }

            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            long sum = 0;

            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i < arr.Count(); i++)
            {
                if (i % 2 == 1)
                {
                    sum += arr.ElementAt(i);
                }
            }

            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            try
            {
                return arr.Distinct();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            try
            {
                return arrA.Intersect(arrB);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            IEnumerable<int> returnArr;

            try
            {
                returnArr = arrA.Except(arrB);

                return returnArr.Union(arrB.Except(arrA));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value           
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            
            for (int i = 0; i < arr.Count(); i++)
            {
                for (int j = i + 1; j < arr.Count(); j++)
                {
                    if (arr.ElementAt(i) + arr.ElementAt(j) == target)
                        return true;
                }
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            List<int> distinctArr = new List<int>();
            List<int> removedArr = new List<int>();

            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            foreach (int intArr in arr)
            {
                if (!removedArr.Contains(intArr))
                {
                    if (distinctArr.Contains(intArr))
                    {
                        distinctArr.Remove(intArr);
                        removedArr.Add(intArr);
                    }
                    else
                    {
                        distinctArr.Add(intArr);
                    }
                }
            }

            return SumArray(distinctArr);
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            
            string substr;
            string doubledString = s;
            
            for (int i = 0; i < s.Length; i++)
            {
                substr = s.Substring(i, 1);
                doubledString = doubledString.Insert(i * 2, substr);
            }

            return doubledString;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<char> charArr = s.ToCharArray();

            return charArr.Count(character => character == c);
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<char> charArr = s.ToCharArray();
            IEnumerable<char> digitOnlyArr = charArr.Where(character => char.IsDigit(character));
            List<int> digitList = new List<int>();

            foreach (char digit in digitOnlyArr)
            {
                digitList.Add((int)Char.GetNumericValue(digit));
            }

            return SumArray(digitList);
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            int startChar = 0;
            int numDigits = 1;
            string number;
            List<int> numbers = new List<int>();

            while (startChar + numDigits <= s.Length)
            {
                int result;

                number = s.Substring(startChar, numDigits);

                int.TryParse(number, out result);

                if (result > 0)
                {
                    numDigits++;
                }
                else
                {
                    number = s.Substring(startChar, numDigits - 1);
                    
                    int.TryParse(number, out result);

                    if (result > 0)
                    {
                        numbers.Add(result);
                    }

                    startChar = startChar + numDigits;
                    numDigits = 1;
                }
            }

            return SumArray(numbers);
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

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
            if (!arr.Any())
                return 0;

            long sum = 0;
            foreach (var i in arr)
            {
                sum += i;
            }
            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            if (!arr.Any())
                return 0;

            long sum = 0;
            foreach (var i in arr)
            {
                if (i % 2 == 1 || i % 2 == -1)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            if (!arr.Any())
                return 0;

            long sum = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    sum += arr.ElementAt(i);
                }
            }
            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            var uniqueArray = new List<int>();
            if (!arr.Any())
                return uniqueArray;

            foreach (var i in arr)
            {
                if (!uniqueArray.Contains(i))
                {
                    uniqueArray.Add(i);
                }
            }
            return uniqueArray;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            var uniqueArray = new List<int>();
            if (!arrA.Any() && !arrB.Any())
                return uniqueArray;

            foreach (var i in arrA)
            {
                if (!uniqueArray.Contains(i))
                {
                    if (arrB.Contains(i))
                        uniqueArray.Add(i);
                }
            }

            return uniqueArray;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            var uniqueArray = new List<int>();
            if (!arrA.Any() && !arrB.Any())
                return uniqueArray;

            foreach (var i in arrA)
            {
                if (!uniqueArray.Contains(i))
                {
                    if (!arrB.Contains(i))
                        uniqueArray.Add(i);
                }
            }

            foreach (var i in arrB)
            {
                if (!uniqueArray.Contains(i))
                {
                    if (!arrA.Contains(i))
                        uniqueArray.Add(i);
                }
            }

            return uniqueArray;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            if (arr == null)
                throw new NullReferenceException();

            if (!arr.Any())
                return false;

            var hasSum = false;
            foreach (var i in arr)
            {
                var diff = target - i;
                if (arr.Contains(Convert.ToInt32(diff)))
                {
                    if (diff == i)
                    {
                        try
                        {
                            //if there is only one value that matches then we can't sum
                            int singleValue = arr.Single(num => num == diff);
                        }
                        catch (InvalidOperationException)
                        {
                            //there are multiples, which means we can sum two values
                            hasSum = true;
                            break;
                        }
                    }
                    else
                    {
                        hasSum = true;
                        break;
                    }
                }
            }

            return hasSum;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            if (!arr.Any())
                return 0;

            var uniqueArray = new List<int>();
            long sum = 0;
            foreach (var i in arr)
            {
                try
                {
                    //if there is only one value that matches then add it to the sum
                    int singleValue = arr.Single(num => num == i);
                    sum += i;
                }
                catch (InvalidOperationException)
                {
                    //there are multiple instances of this value, so do not include it in the sum
                }
            }
            return sum;
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            if(s == null)
                throw new ArgumentNullException();

            var outputString = new StringBuilder();
            foreach (var c in s)
            {
                outputString.Append(c, 2);
            }
            return outputString.ToString();
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            if (s == null)
                throw new ArgumentNullException();

            var sum = 0;
            foreach (var character in s)
            {
                if (character == c)
                    sum++;
            }
            return sum;
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            if (s == null)
                throw new ArgumentNullException();

            long sum = 0;
            foreach (var c in s)
            {
                if (Char.IsDigit(c))
                    sum += Convert.ToInt32(Char.GetNumericValue(c));
            }
            return sum;
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            if (s == null)
                throw new ArgumentNullException();

            long sum = 0;
            var value = string.Empty;
            var charArray = s.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (Char.IsDigit(charArray[i]))
                {
                    value += charArray[i];
                    if (i + 1 == charArray.Length || !Char.IsDigit(charArray[i+1]))
                    {
                        sum += Convert.ToInt32(value);
                        value = string.Empty;
                    }
                }
            }
            return sum;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            if (s1 == null || s2 == null)
                throw new NullReferenceException();

            if (s1.Length != s2.Length)
                return false;

            var charArray1 = s1.ToCharArray();
            var charArray2 = s2.ToCharArray();
            Array.Sort(charArray1);
            Array.Sort(charArray2);
            return charArray1.SequenceEqual(charArray2);
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            if (count1 > 21 && count2 > 21)
                return 0;

            if (count1 > 21)
                return count2;

            if (count2 > 21)
                return count1;

            return count1 > count2 ? count1 : count2;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            var playerHands = new int[] {count1, count2, count3, count4, count5};
            Array.Sort(playerHands);
            for (int i = (playerHands.Length - 1); i >= 0; i--)
            {
                if (playerHands[i] <= 21)
                    return playerHands[i];
            }

            return 0;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            var playerHands = counts.ToArray();
            Array.Sort(playerHands);
            for (int i = (playerHands.Length - 1); i >= 0; i--)
            {
                if (playerHands[i] <= 21)
                    return playerHands[i];
            }

            return 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            if (arr == null)
                throw new NullReferenceException();

            var output = new Dictionary<String, int>();
            foreach (var word in arr)
            {
                var count = 1;
                if (output.ContainsKey(word))
                {
                    count = output[word];
                    output[word] = count + 1;
                }
                else
                {
                    output.Add(word, count);
                }
            }
            return output;
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

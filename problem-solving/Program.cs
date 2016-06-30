using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace problem_solving
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listA = new List<int>(new[] { 1, 1, 2, 3, 3, 4, 5, 5, 6, 7, 7, 8, 9, 10 });
            var listB = new List<int>(new[] { 1,3, 4, 6, 8, 9, 10 });
            var nPlayerBlackJack = new List<int>(new[] {20,23,25,15,14,7,11});
            const string doubleString = "PEACE";
            const string countChar = "PEEAACE";
            const string c = "A";
            const string sumDigits = "P1E22A33C4E55";
            const int factorial = 9;

            Console.WriteLine("Sum of All Values: "+SumArray(listA));
            Console.WriteLine("Sum of Odd Values: " + SumArrayOddValues(listA));
            Console.WriteLine("Sum of every second value: " + SumArrayEverySecondValue(listA));
            Console.WriteLine("List of unique values");
            foreach (var uniqueList in GetUniqueValues(listA))
                Console.WriteLine("      " + Convert.ToString(uniqueList));
            Console.WriteLine("List of intersect values");
            foreach (var uniqueList in GetArrayIntersect(listA, listB))
                Console.WriteLine("      " + Convert.ToString(uniqueList));
            Console.WriteLine("List of non intersect values");
            foreach (var uniqueList in GetArrayNotIntersect(listA, listB))
                Console.WriteLine("      " + Convert.ToString(uniqueList));
            Console.WriteLine("Has Sum : " + (HasSum(listA,5) ? "Yes" : "No"));
            Console.WriteLine("Lone Sum: " + LoneSum(listA));
            Console.WriteLine("Double String: "+ DoubleString(doubleString));
            Console.WriteLine("Count Chars: " + CountChars(countChar,Convert.ToChar(c)));
            Console.WriteLine("Sum Digits: " + SumDigits(sumDigits));
            Console.WriteLine("Sum Numbers: " + SumNumbers(sumDigits));
            Console.WriteLine("Is Anagram : " + (IsAnagram("care","erac") ? "Yes" : "No"));
            Console.WriteLine("BlackJack value: " + BlackJack(23,20));
            Console.WriteLine("Five Player BlackJack: " + FivePlayerBlackJack(10,11,15,30,1));
            Console.WriteLine("N Player BlackJack: " + NPlayerBlackJack(nPlayerBlackJack));
            Console.WriteLine("Factorial of {0} is : " + Factorial(factorial), factorial);
            Console.ReadLine();
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array
            return arr.Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            return arr.Where(i=> i%2 != 0).Sum();
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            return arr.Skip(1).Where((c, i) => i%2 == 0).Sum();

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
            return arrA.Except(arrB);
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            foreach (var i in arr)
            {
                
            }
            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            var sum = 0;
            var previousValue = 0;
            foreach (var i in arr)
            {
                if (i != previousValue)
                    sum += i;

                previousValue = i;
            }
            return sum;
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            return s.Aggregate(string.Empty, (current, c) => current + (Convert.ToString(c) + Convert.ToString(c)));
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            return s.Count(x => x == c);
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            return s.Where(c => c > '0' && c <= '9').Sum(c => (int) Char.GetNumericValue(c));
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            var a = s.Where(c => c > '0' && c <= '9');
            
            return 0;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            return string.Concat(s1.Reverse()).Equals(s2);
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            return (count1 > 21) && (count2 > 21) ? 0 : ((21 - count1) > (21 - count2) ? count1 : count2);
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            if ((count1 > 21) && (count2 > 21) && (count3 > 21) && (count4 > 21) && (count5 > 21))
                return 0;

            var dictionary = new Dictionary<string, int>();

            if (count1 < 21) dictionary.Add(Convert.ToString(count1), (21 - count1));
            if (count2 < 21) dictionary.Add(Convert.ToString(count2), (21 - count2));
            if (count3 < 21) dictionary.Add(Convert.ToString(count3), (21 - count3));
            if (count4 < 21) dictionary.Add(Convert.ToString(count4), (21 - count4));
            if (count5 < 21) dictionary.Add(Convert.ToString(count5), (21 - count5));

            return Convert.ToInt32(dictionary.Max(k => k.Key));
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            var c = counts.Count(n => n > 21);

            if (c == counts.Count())
                return 0;

            var dictionary = counts.Where(count => count < 21).ToDictionary(count => Convert.ToString(count));

            return Convert.ToInt32(dictionary.Max(a => a.Value));
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
            var factorial = 1;

            for (var counter = 1; counter <= n; counter++)
            {
                factorial = factorial*counter;
            }

            return factorial;
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

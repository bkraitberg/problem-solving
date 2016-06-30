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

            if (arr == null) throw new ArgumentNullException();

            long sum = 0;

            foreach (long value in arr)
            {
                sum += value;
            }
            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            // TODO
            if (arr == null) throw new ArgumentNullException();

            long sum = 0;

            foreach (long value in arr)
            {
                if (Math.Abs(value % 2) == 1) sum += value;
            }
            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            // TODO
            if (arr == null) throw new ArgumentNullException();

            long sum = 0;
            int counter = 1;

            foreach (long value in arr)
            {
                if (counter % 2 == 0) sum += value;
                counter++;
            }
            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            // TODO
            if (arr == null) throw new ArgumentNullException();

            return arr.Distinct<int>();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            // TODO
            if (arrA == null || arrB == null) throw new ArgumentNullException();

            List<int> intersect = new List<int>();

            foreach (int value in arrA)
            {
                if (arrB.Contains(value) && !intersect.Contains(value)) intersect.Add(value);
            }

            return intersect;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            // TODO
            if (arrA == null || arrB == null) throw new ArgumentNullException();

            List<int> inverseIntersect = new List<int>();

            foreach (int value in arrA)
            {
                if (!arrB.Contains(value) && !inverseIntersect.Contains(value)) inverseIntersect.Add(value);
            }

            foreach (int value in arrB)
            {
                if (!arrA.Contains(value) && !inverseIntersect.Contains(value)) inverseIntersect.Add(value);
            }

            return inverseIntersect;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            // TODO
            if (arr == null) throw new NullReferenceException();

            bool hasSum = false;

            for (int i = 0; i < arr.Count() - 1 && !hasSum; i++)
            {
                for (int j = i + 1; j < arr.Count() && !hasSum; j++)
                {
                    hasSum = arr.ElementAt(i) + arr.ElementAt(j) == target;
                }
            }

            return hasSum;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            if (arr == null) throw new ArgumentNullException();

            long sum = 0;

            foreach (int value in arr)
            {
                // check each value if it is unique.  if a value is not unique, remove it from the list.
                if (arr.Count(x => x.Equals(value)) == 1)
                {
                    sum += value;
                }
            }

            return sum;
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            if (s == null) throw new ArgumentNullException();

            String doubledString = "";
            char[] charList = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                doubledString += charList[i].ToString() + charList[i].ToString();
            }
            return doubledString;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            if (s == null) throw new ArgumentNullException();

            return s.Count(x => x.Equals(c));
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            if (s == null) throw new ArgumentNullException();

            int sum = 0;
            char[] charList = s.ToCharArray();

            foreach (char value in charList)
            {
                if ((value >= '0') && (value <= '9'))
                {
                    sum += int.Parse(value.ToString());
                }
            }

            return sum;
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            if (s == null) throw new ArgumentNullException();

            string[] numbers = Regex.Split(s, @"\D+");
            int sum = 0;

            foreach (string value in numbers)
            {
                if (value != string.Empty)
                {
                    int number = int.Parse(value);
                    sum += number;
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
            if (s1 == null || s2 == null) throw new NullReferenceException();

            char[] arr1 = s1.ToCharArray();
            char[] arr2 = s2.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            string s1Sorted = new string (arr1);
            string s2Sorted = new string (arr2);

            if (s1Sorted.Equals(s2Sorted)) return true;

            return false;
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.

            const int BLACKJACK_MAGIC = 21;

            if (BLACKJACK_MAGIC - count1 >= 0 && (count1 >= count2 || count2 > BLACKJACK_MAGIC)) return count1;
            else if (BLACKJACK_MAGIC - count2 >= 0 && (count2 >= count1 || count1 > BLACKJACK_MAGIC)) return count2;
            else return 0;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.

            List<int> cards = new List<int> { count1, count2, count3, count4, count5};

            return NPlayerBlackJack(cards);
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            const int BLACKJACK_MAGIC = 21;
            List<int> cards = new List<int>();
            cards.AddRange(counts);

            cards.Sort();
            int winningNumber = 0;

            foreach (int card in cards.Reverse<int>())
            {
                if (card <= BLACKJACK_MAGIC)
                {
                    winningNumber = card;
                    break;
                }
            }

            return winningNumber;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array

            if (arr == null) throw new NullReferenceException();

            List<String> distinctStrings = new List<String>();
            distinctStrings.AddRange(arr.Distinct<String>());

            Dictionary<String, int> wordCount = new Dictionary<string,int>();

            foreach (string distinctValue in distinctStrings)
            {
                wordCount.Add(distinctValue, arr.Count(x => x.Equals(distinctValue)));
            }

            return wordCount;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1

            if (n == 0) n = 1;

            int factorial = n;

            while (n > 1)
            {
                factorial *= (n - 1);
                n -= 1;
            }

            return factorial;
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"

            List<String> output = new List<String>();
            string divisibleByThree = "Fizz";
            string divisibleByFive = "Buzz";
            
            while (n >= 1)
            {
                string outputWord = "";
                if (n % 3 == 0) outputWord += divisibleByThree;
                if (n % 5 == 0) outputWord += divisibleByFive;
                if (String.IsNullOrEmpty(outputWord)) outputWord = n.ToString();
                output.Insert(0,outputWord);
                n -= 1;
            }
            return output;
        }
    }
}

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
            if (arr == null)
                throw new ArgumentNullException();

            long sum = 0;

            foreach(int i in arr)
            {
                sum += i;
            }

            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            if (arr == null)
                throw new ArgumentNullException();

            long sum = 0;

            foreach(int i in arr)
            {
                if (i % 2 != 0)
                    sum += i;
            }

            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            if (arr == null)
                throw new ArgumentNullException();

            long sum = 0;
            IEnumerator<int> pointer = arr.GetEnumerator();

            pointer.MoveNext();
            while (pointer.MoveNext() == true) 
            {
                sum += pointer.Current;
                pointer.MoveNext();
            } 
            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            if (arr == null)
                throw new ArgumentNullException();

            List<int> list = new List<int>();

            foreach(int i in arr)
            {
                if (list.Contains(i) == false)
                    list.Add(i);
            }

            return list;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            if (arrA == null || arrB == null)
                throw new ArgumentNullException();

            List<int> list = new List<int>();
            IEnumerable<int> arrLong = arrB;
            IEnumerable<int> arrShort = arrA;

            if(arrA.Count() > arrB.Count())
            {
                arrLong = arrA;
                arrShort = arrB;
            }

            foreach (int i in arrShort)
            {
                if(arrLong.Contains<int>(i))
                    list.Add(i);
            }

            return list;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            if (arrA == null || arrB == null)
                throw new ArgumentNullException();

            List<int> list = new List<int>();

            foreach (int i in arrA)
            {
                if (!arrB.Contains<int>(i))
                    list.Add(i);
            }
            foreach (int i in arrB)
            {
                if (!arrA.Contains<int>(i))
                    list.Add(i);
            }

            return list;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            if (arr == null)
                throw new NullReferenceException();

            Boolean hasSum = false;

            for (int i = 0; i < arr.Count()-1 && hasSum == false; ++i )
            {
                for(int j = i+1; j < arr.Count() && hasSum == false; ++j)
                {
                    if (arr.ElementAt(i) + arr.ElementAt(j) == target)
                        hasSum = true;
                }
            }

            return hasSum;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.
            if (arr == null)
                throw new ArgumentNullException();

            long sum = 0;

            foreach(int i in arr)
            {
                if (!(arr.Count(x => x == i) > 1))
                    sum += i;
            }

            return sum;
        }

        public static String DoubleString(String s)
        {
            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            if (s == null)
                throw new ArgumentNullException();

            String result = "";
            foreach (char c in s)
            {
                result += c.ToString() + c.ToString();
            }

            return result;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            if (s == null)
                throw new ArgumentNullException();

            int count = 0;
            foreach(char i in s)
            {
                if (i == c)
                    ++count;
            }
            return count;
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            if (s == null)
                throw new ArgumentNullException();

            long sum = 0;
            foreach (char c in s)
            {
                if (Char.GetNumericValue(c) != -1.0)
                    sum += (long)Char.GetNumericValue(c);

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

            String temp = "";
            bool isNumber = false;
            long sum = 0;

            foreach(char c in s)
            {
                if(Char.GetNumericValue(c) != -1.0)
                {
                    isNumber = true;
                    temp += c.ToString();
                } 
                else if(isNumber == true)
                {
                    sum += Convert.ToInt64(temp);
                    temp = "";
                    isNumber = false;
                }
            }
            if(isNumber == true)
                sum += Convert.ToInt64(temp);

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

            Boolean result = false;

            char[] c1 = s1.ToArray<char>();
            char[] c2 = s2.ToArray<char>();
            Array.Sort(c1);
            Array.Sort(c2);
            s1 = new string(c1);
            s2 = new string(c2);

            int r = String.Compare(s1, s2);

            if (r == 0)
            {
                result = true;
            }

            return result;
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            int result = 0;
            
            if(count1 > 21 || count2 > 21)
            {
                if (count1 < 21)
                    result = count1;
                else if (count2 < 21)
                    result = count2;
            }
            else
            {
                if (21 - count1 <= 21 - count2)
                {
                    result = count1;
                }
                else
                {
                    result = count2;
                }
            }

            return result;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            int[] i = { count1, count2, count3, count4, count5 };
            Array.Sort(i);
            int result = 0;

            for (int j = 0; j < i.Length; ++j )
            {
                if (i[j] <= 21)
                    result = i[j];
            }

            return result;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            if (counts == null)
                throw new ArgumentNullException();

            int[] i = counts.ToArray();
            Array.Sort(i);
            int result = 0;

            for (int j = 0; j < i.Length; ++j)
            {
                if (i[j] <= 21)
                    result = i[j];
            }

            return result;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            if (arr == null)
                throw new NullReferenceException();
            Dictionary<String, int> dict = new Dictionary<string,int>();

            foreach(string s in arr)
            {
                if(dict.ContainsKey(s))
                {
                    dict[s]++;
                } else
                {
                    dict.Add(s, 1);
                }
            }

            return dict;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            int result = 1;
            for (int i = 1; i <= n; ++i )
            {
                result = result * i;
            }
            return result;
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            List<String> list = new List<string>();
            for (int i = 1; i <= n; ++i )
            {
                if (i % 3 == 0 && i % 5 == 0)
                    list.Add("FizzBuzz");
                else if (i % 3 == 0)
                    list.Add("Fizz");
                else if (i % 5 == 0)
                    list.Add("Buzz");
                else
                    list.Add(i.ToString());
            }
            return list;
        }
    }
}

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

            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            long result = arr.Sum();

            return result;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {

            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            int[] arr1 = arr.ToArray();
            long sum = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] % 2 == 1)
                {
                    sum += arr1[i];
                }
            }

            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            int[] arr1 = arr.ToArray();
            long sum = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum += arr1[i];
                }
            }

            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            int[] res = arr.Distinct().ToArray();

            return res;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {

            if (arrA == null)
            {
                throw new ArgumentNullException();
            }
            if (arrB == null)
            {
                throw new ArgumentNullException();
            }

            return arrA.Intersect(arrB);
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null)
            {
                throw new ArgumentNullException();
            }
            if (arrB == null)
            {
                throw new ArgumentNullException();
            }


            return (arrA.Except(arrB).Union(arrB.Except(arrA)));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            int length = arr.Count();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j && arr.ElementAt(i) + arr.ElementAt(j) == target)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            int[] x = arr.Distinct().ToArray();
            long sum = x.Sum();

            return sum;
        }

        public static String DoubleString(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                result.Append(s[i]);
                result.Append(s[i]);
            }
            Console.WriteLine(result.ToString());
            Console.ReadKey();
            return result.ToString();
        }

        public static int CountChars(String s, char c)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            int count = 0;
            foreach (char schar in s.ToCharArray())
            {
                if (c == schar)
                {
                    count++;
                }
            }
            return count;
        }

        public static long SumDigits(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            long sum = 0;
            char[] chars = s.ToCharArray();
            foreach (char ch in chars)
            {
                if (Char.IsDigit(ch))
                {
                    sum += (ch - '0');
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
            return false;
        }

        public static int BlackJack(int count1, int count2)
        {
            if (count1 > 21)
            {
                if (count2 > 21)
                {
                    return 0;
                }
                return count2;
            }
            if (count2 > 21)
            {
                return count1;
            }
            int result = Math.Max(count1, count2);
            return result;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            int lim = 21;
            var valid = new List<int>();
            if (count1 <= lim)
            {
                valid.Add(count1);
            }
            if (count2 <= lim)
            {
                valid.Add(count2);
            }
            if (count3 <= lim)
            {
                valid.Add(count3);
            }
            if (count4 <= lim)
            {
                valid.Add(count4);
            }
            if (count5 <= lim)
            {
                valid.Add(count5);
            }
            if (valid.Count == 0)
            {
                return 0;
            }
            else
            {
                return valid.Max();
            }
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            if (counts == null)
            {
                throw new ArgumentNullException();
            }
           var valid = counts.Where(c => c <= 21); 
           if (valid.Any()) 
             {
     
                return valid.Max(); 
            } 
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
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n == 0)
            {
                return 1;
            }
            int result = 1;
            for (int i = 1; i <= n; ++i)
            {
                result = result * i;
            }
            return result;

        }

        public static List<String> FB(int n)
        {
            List<string> result = new List<string>();


            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }
    }
}

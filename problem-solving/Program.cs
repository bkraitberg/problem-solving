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
            long sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            // return the sum of all the values in the array
            // TODO
            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            long sumOdd = 0;
            foreach (int i in arr)
            {
                if (i % 2 != 0)
                {
                    sumOdd += i;
                }
            }
            return sumOdd;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            long sumEveryOther = 0;
            int count = 0;
            foreach (int i in arr)
            {
                if (count % 2 == 1)
                {
                    sumEveryOther += i;
                }
                count++;
            }
            return sumEveryOther;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            HashSet<int> uniqueValues = new HashSet<int>();
            foreach(int i in arr)
            {
                uniqueValues.Add(i);
            }
            return uniqueValues;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null || arrB == null)
            {
                throw new ArgumentNullException();
            }
            IEnumerable<int> setA = GetUniqueValues(arrA);
            IEnumerable<int> setB = GetUniqueValues(arrB);
            List<int> intersect = new List<int>();
            foreach (int i in setA)
            {
                if (setB.Contains(i))
                {
                    intersect.Add(i);
                }
            }
            return intersect;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null || arrB == null)
            {
                throw new ArgumentNullException();
            }
            IEnumerable<int> setA = GetUniqueValues(arrA);
            IEnumerable<int> setB = GetUniqueValues(arrB);
            List<int> intersect = new List<int>();

            foreach (int i in setA)
            {
                if (!setB.Contains(i))
                {
                    intersect.Add(i);
                }
            }
            foreach (int i in setB)
            {
                if (!setA.Contains(i))
                {
                    intersect.Add(i);
                }
            }
            return intersect;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            int length = arr.Count();
            for(int i = 0; i < length; i++)
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
            HashSet<int> uniqueValues = new HashSet<int>();
            HashSet<int> toRemove = new HashSet<int>();
            foreach (int i in arr)
            {
                if (!uniqueValues.Contains(i))
                {
                    uniqueValues.Add(i);
                }
                else
                {
                    toRemove.Add(i);
                }
            }
            foreach (int i in toRemove)
            {
                uniqueValues.Remove(i);
            }
            return SumArray(uniqueValues);
        }

        public static String DoubleString(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            string doubleString = "";
            foreach (char c in s)
            {
                doubleString += c + "" + c;
            }
            return doubleString;
        }

        public static int CountChars(String s, char c)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            int cCount = 0;
            foreach (char ch in s)
            {
                if (ch == c)
                {
                    cCount++;
                }
            }
            return cCount;
        }

        public static long SumDigits(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            int digits = 0;
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    digits += c-'0';
                }
            }
            return digits;
        }

        public static long SumNumbers(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            String currString = "";
            List<String> numbers = new List<String>();
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    currString += c;
                }
                else
                {
                    if (!currString.Equals(""))
                    {
                        numbers.Add(currString);
                        currString = "";
                    }
                }
            }
            if (!currString.Equals(""))
            {
                numbers.Add(currString);
            }
            int sum = 0;
            foreach (String number in numbers)
            {
                sum += Convert.ToInt32(number);
            }
            return sum;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1 == null || s2 == null)
            {
                throw new NullReferenceException();
            }

            if (s1.Count() != s2.Count())
            {
                return false;
            }
            List<char> temp1 = s1.ToList();
            List<char> temp2 = s2.ToList();

            temp1.Sort();
            temp2.Sort();
            int ix = 0;
            foreach (char c in temp1)
            {
                if (temp2[ix] != c)
                {
                    return false;
                }
                ix++;
            }

            return true;
        }

        public static int BlackJack(int count1, int count2)
        {
            if (count1 > 21 && count2 > 21)
            {
                return 0;
            }
            else if (count1 > 21)
            {
                return count2;
            }
            else if (count2 > 21)
            {
                return count1;
            }
            else
            {
                return count1 >= count2 ? count1 : count2;
            }
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            List<int> counts = new List<int>() { count1, count2, count3, count4, count5 };
            return NPlayerBlackJack(counts);
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            int best = 0;
            if (counts.Count() == 1)
            {
                return counts.ElementAt(0) > 21 ? 0 : counts.ElementAt(0); 
            }

            for (int i = 0; i < counts.Count(); i++)
            {
                for (int j = 1; j < counts.Count(); j++)
                {
                    int temp = BlackJack(counts.ElementAt(i), counts.ElementAt(j));
                    if (temp > best)
                    {
                        best = temp;
                    }
                }
            }
            return best;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            Console.WriteLine("Test");
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            Dictionary<String, int> dict = new Dictionary<String, int>();
            foreach (String s in arr)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s]++;
                }
                else
                {
                    dict.Add(s, 1);
                }
                Console.WriteLine(s);
                
            }
            return dict;
        }

        public static int Factorial(int n)
        {
            int result = 1;

            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n-1);
            }
        }

        public static List<String> FB(int n)
        {
            List<String> fizzbuzzes = new List<String>();
            for (int i = 1; i <= n; i++)
            {
                String fizzBuzz = "";
                if (i % 3 == 0)
                {
                    fizzBuzz += "Fizz";
                }
                if (i % 5 == 0)
                {
                    fizzBuzz += "Buzz";
                }

                if (fizzBuzz.Equals(String.Empty))
                {
                    fizzBuzz = "" + (i);
                }
                Console.WriteLine(fizzBuzz);
                fizzbuzzes.Add(fizzBuzz);
            }
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            return fizzbuzzes;
        }
    }
}

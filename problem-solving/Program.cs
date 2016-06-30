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
            if(arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            long total = 0;
            foreach(int val in arr)
            {
                total += val;
            }
            return total;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            long total = 0;
            foreach (int val in arr)
            {
                if (val % 2 != 0)
                {
                    total += val;
                }
            }
            return total;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            long total = 0;
            IEnumerator<int> values = arr.GetEnumerator();
            
            while(values.MoveNext() && values.MoveNext())
            {
                total += values.Current;
            }
            return total;
        }

        public static IEnumerable<int> GetDistinctValues(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null)
            {
                throw new ArgumentNullException("arrA");
            }
            if (arrB == null)
            {
                throw new ArgumentNullException("arrB");
            }
            
            var intersectedDistinct = arrA.Distinct().Where(t => arrB.Contains(t));

            List<int> arrayIntersect = new List<int>();

            foreach(int val in intersectedDistinct)
            {
                for(int i = Math.Min(arrA.Count(t=>t == val), arrB.Count(r=>r == val)); i > 0;i--)
                {
                    arrayIntersect.Add(val);
                }
            }
            return arrayIntersect;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null)
            {
                throw new ArgumentNullException("arrA");
            }
            if (arrB == null)
            {
                throw new ArgumentNullException("arrB");
            }
            return arrA.Where(t => !arrB.Contains(t)).Union(arrB.Where(t=>!arrA.Contains(t)));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            
            return arr.Any(t => t < ((target + 1) / 2) && arr.Contains((int)(target - t))
                || (target % 2 == 0) && arr.Count(r => r == target / 2) > 1);
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException("arr");
            }
            long sum = 0;

            foreach(int value in arr)
            {
                if(arr.Count(t=>t==value) == 1)
                {
                    sum += value;
                }
            }

            return sum;
        }

        public static String DoubleString(String s)
        {
            if(s == null)
            {
                throw new ArgumentNullException("s");
            }
            StringBuilder sb = new StringBuilder();
            for(int i = 0;i<s.Length;i++)
            {
                sb.Append(s[i]);
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        public static int CountChars(String s, char c)
        {
            if(s == null)
            {
                throw new ArgumentNullException("s");
            }
            int count = 0;
            foreach (char arrayChar in s.ToCharArray())
            {
                if(c == arrayChar)
                {
                    count++;
                }
            }
            return count;
        }

        public static long SumDigits(String s)
        {
            if(s == null)
            {
                throw new ArgumentNullException("s");
            }
            long sum = 0;
            char[] chars = s.ToCharArray();
            foreach(char c in chars)
            {
                if(IsDigit(c))
                {
                    sum += (c - '0');
                }
            }
            return sum;
        }

        public static long SumNumbers(String s)
        {
            if(s == null)
            {
                throw new ArgumentNullException("s");
            }
            long sum = 0;

            char[] chars = s.ToCharArray();
            int startIndex = -1;
            int index = 0;

            while(index < chars.Length)
            {
                if (startIndex == -1)
                {
                    if (IsDigit(chars[index]))
                    {
                        startIndex = index;
                    }
                }
                else if (!IsDigit(chars[index]))
                {
                    sum += Int64.Parse(s.Substring(startIndex, (index - startIndex)));
                    startIndex = -1;
                }
                
                index++;                
            }
            if(startIndex > -1)
            {
                sum += Int64.Parse(s.Substring(startIndex, (index - startIndex)));
            }

            return sum;
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1 == null)
            {
                throw new ArgumentNullException("s1");
            }
            if(s2 == null)
            {
                throw new ArgumentNullException("s2");
            }
            string sorted1 = new string(s1.OrderBy(t => t).ToArray());
            string sorted2 = new string(s2.OrderBy(t => t).ToArray());
            return sorted1 == sorted2;
        }

        public static int BlackJack(int count1, int count2)
        {
            if(count1 > 21)
            {
                if(count2 > 21)
                {
                    return 0;
                }
                return count2;
            }
            if(count2 > 21)
            {
                return count1;
            }
            return Math.Max(count1, count2);
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            List<int> list = new List<int>() { count1, count2, count3, count4, count5 };
            var eligibleList = list.Where(t => t <= 21);
            if(eligibleList.Any())
            {
                return eligibleList.Max();
            }
            return 0;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            var eligibleList = counts.Where(t => t <= 21);
            if (eligibleList.Any())
            {
                return eligibleList.Max();
            }
            return 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach(string s in arr)
            {
                if(dictionary.ContainsKey(s))
                {
                    dictionary[s]++;
                }
                else
                {
                    dictionary[s] = 1;
                }
            }
            return dictionary;
        }

        public static int Factorial(int n)
        {
            if(n < 0)
            {
                throw new ArgumentOutOfRangeException("n");
            }
            if(n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        public static List<String> FB(int n)
        {
            List<string> strings = new List<string>();

            for (int i = 1; i <= n;i++ )
            {
                if(i % 15 == 0)
                {
                    strings.Add("FizzBuzz");
                }
                else if(i % 5 == 0)
                {
                    strings.Add("Buzz");
                }
                else if (i % 3 == 0)
                {
                    strings.Add("Fizz");
                }
                else
                {
                    strings.Add(i.ToString());
                }
            }

            return strings;
        }
    }
}

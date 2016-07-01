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

        private static void checkNull(Object arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            checkNull(arr);
            long result = 0;

            foreach (int i in arr)
            {
                result += i;
            }
            return result;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            checkNull(arr);
            int sum = 0;
            foreach (int i in arr)
            {
                if (i % 2 == 1 || i%2 == -1)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            checkNull(arr);
            int sum = 0;
            List<int> list = arr.ToList();
            for (int i = 0; i < list.Count; i++ )
            {
                if (i % 2 == 1)
                {
                    sum += list[i];
                }
            }
            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA.Intersect(arrB); ;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA.Except(arrB).Union(arrB.Except(arrA));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            if (arr.Count() <= 1)
            {
                return false;
            }
            List<int> list = arr.ToList();
            list.Sort();
            int left = 0;
            int right = list.Count()-1;

            while (left < right)
            {
                int sum = list[left] + list[right];

                if(sum == target)
                { 
                    return true;
                }
                if (sum > target)
                {
                    right--;
                }
                if (sum < target)
                {
                    left++;
                }       
            }
            
            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            return arr.GroupBy(x => x)
                .Where(g => g.Count() <= 1)
                .Select(g => g.Key).Sum();
        }
        
        public static String DoubleString(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            String newS = "";
            foreach (char c in s)
            {
                newS += c + "" + c;
            }

            return newS;
        }

        public static int CountChars(String s, char c)
        {
            checkNull(s);
            int occur = 0;
            foreach (char ch in s)
            {
                if (ch == c)
                {
                    occur++;
                }
            }
            return occur;
        }

        public static long SumDigits(String s)
        {
            int sum = 0;
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            foreach (char c in s)
            {
                if (Char.IsDigit(c)) { 
                    sum += Int32.Parse(c.ToString());
                }
            }
            return sum;
        }

        public static long SumNumbers(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            string[] split = Regex.Split(s, @"\D+");
            long value = 0;
            foreach(string i in split) {
                if (i.Length > 0) { 
                    value += long.Parse(i);
                }
            }
            return value;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1 == null || s2 == null)
            {
                throw new NullReferenceException();
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();
            Array.Sort(c1);
            Array.Sort(c2);

            for (int i = 0; i < c1.Length; i++)
            {
                if (c1[i] != c2[i])
                {
                    return false;
                }
            }
                return true;
        }

        private static int blackHelper(List<int> arr) {
            List<int> newArr = arr.Where(i => i <= 21).ToList();
            if (newArr.Count > 0)
            {
                return newArr.OrderBy(j => 21 - j).First();
            }
            return 0;
        }

        public static int BlackJack(int count1, int count2)
        {
            List<int> arr = new List<int>();
            arr.Add(count1);
            arr.Add(count2);
            return blackHelper(arr);
         
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            List<int> arr = new List<int>();
            arr.Add(count1);
            arr.Add(count2);
            arr.Add(count3);
            arr.Add(count4);
            arr.Add(count5);
            return blackHelper(arr);
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            return blackHelper(counts.ToList());
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            Dictionary<String, int> dict = new Dictionary<string, int>();
            foreach (String s in arr)
            {
                if (dict.ContainsKey(s))
                {
                    dict[s] = dict[s]+1;
                    
                }
                else
                {
                    dict.Add(s, 1);
                }
            }
            return dict;
        }

        public static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        public static List<String> FB(int n)
        {
            List<String> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                string add = "";
                if (i % 3 == 0)
                {
                    add += "Fizz";
                }
                if( i % 5 == 0) {
                    add += "Buzz";
                }
                if(add.Length == 0) {
                    add = i + "";
                }
                result.Add(add);
            }
            return result;       
        }
    }
}

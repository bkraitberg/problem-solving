using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            long[] b = Array.ConvertAll(arr.ToArray(), val => (long)val);
            return b.Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            var result = arr.Where(x => Math.Abs(x % 2) == 1);
            return result.Sum();
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            int[] result = arr.Where((value, index) => (index+1) % 2 == 0)
              .ToArray();
            return result.Sum();
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            return arr.Distinct().ToArray(); ;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA.Intersect(arrB);
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null || arrB == null)
            {
                throw new ArgumentNullException();
            }
            IEnumerable<int> enumA = arrA.Distinct();
            IEnumerable<int> enumB = arrB.Distinct();
            List<int> intersect = new List<int>();
            intersect.AddRange(enumA.Except(enumB).ToList());
            intersect.AddRange(enumB.Except(enumA).ToList());
            return intersect;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr.ToArray().Length<=1)
            {
                return false;
            }
            var arrlist = arr.ToArray();
            for(int i=0;i<arrlist.Length;i++)
            {
                var x = arrlist[i];
                var found = Array.IndexOf(arrlist, (int) (target - x));
                if ( found!= -1 &&found!=i)
                {
                    return true;
                }
            }
            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            var result = from x in arr.ToList()
                         group arr by x into el
                         where el.Count() == 1
                         select el.Key;
            
            return result.Sum();
        }

        public static String DoubleString(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            var result = "";
            foreach (var ch in s)
            {
                result = result + ch + ch;
            }
            return result;
        }

        public static int CountChars(String s, char c)
        {
            return s.Count(x => x == c);
        }

        public static long SumDigits(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            char[] charArr = s.ToCharArray().Where(x=>char.IsDigit(x)).ToArray();
            int[] intArr = Array.ConvertAll(charArr, c => (int)Char.GetNumericValue(c));
            return intArr.Sum();
        }

        public static long SumNumbers(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            var str = "";
            foreach (var ch in s)
            {
                if (!char.IsDigit(ch))
                {
                    str = str + " ";
                }
                else
                {
                    str = str + ch;
                }
            }
            string[] strArr = str.Split(' ').Where(x => x.Length > 0).ToArray();
            int[] intArr = Array.ConvertAll(strArr, c => Int32.Parse(c));
            return intArr.Sum();
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1.Length!=s2.Length)
            {
                return false;
            }
            string s11 = String.Concat(s1.OrderBy(c => c));
            string s22 = String.Concat(s2.OrderBy(c => c));
            return s11 == s22;
        }

        public static int BlackJack(int count1, int count2)
        {
            if (count1 == int.MaxValue && count2<21)
            {
                return count2;
            }

            if (count2 == int.MaxValue && count1 < 21)
            {
                return count1;
            }
            
            if (count1 <= 21 && count2 <= 21)
            {
                return (count1 > count2) ? count1 : count2;
            }

            if (count1!=int.MaxValue&&count2!=int.MaxValue&&(count2+count1)<=42)
            {
                return (count1 > 21) ? count2 : count1;  
            }
          
            
            return 0;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            int[] counts = new[] {count1, count2, count3, count4, count5};
            var lessThan21 = counts.Where(x => x <= 21).ToArray();
            Array.Sort(lessThan21);
            if (lessThan21.Length > 0)
            {
                return lessThan21.Last();
            }
            return 0;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            
            var lessThan21 = counts.Where(x => x <= 21).ToArray();
            Array.Sort(lessThan21);
            if (lessThan21.Length>0)
            {
                return lessThan21.Last();
            }
            return 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
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
            }
            return dict;
        }

        public static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int result =n;

            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }
            return result;

        }

        public static List<String> FB(int n)
        {
            
            List<String> result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int k = i + 1;
                if (k%3 == 0 && k%5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if(k%3==0)
                {
                    result.Add("Fizz");
                }
                else if(k%5==0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(k.ToString());
                }
            }
            return result;
        }
    }
}

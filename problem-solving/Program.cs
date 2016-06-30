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
            return arr.Select(n => (long)n).Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            return arr.Where(number => number % 2 != 0).Select(n => (long)n).Sum();
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            return arr.Where((number, ix) => ix % 2 != 0).Sum();
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            return arr.Distinct();
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA.Distinct().Where(number => arrB.Contains(number));
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            return arrA.Except(arrB).Concat(arrB.Except(arrA));
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            var set = new HashSet<int>();
            foreach (int number in arr)
            {
                if(set.Contains((int)target-number))
                {
                    return true;
                }
                set.Add(number);
            }
            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            if (arr == null) throw new ArgumentNullException();

            var addedNums = new HashSet<int>();
            var duplicates = new HashSet<int>();
            int sum = 0;
            foreach (int number in arr)
            {
                if(!addedNums.Contains(number))
                {
                    sum += number;
                    addedNums.Add(number);
                }
                else if (!duplicates.Contains(number))
                {
                    duplicates.Add(number);
                    sum -= number;
                }
            }
            return sum;
        }

        public static String DoubleString(String s)
        {
            if (s == null) throw new ArgumentNullException();

            char[] charArray = new char[s.Length*2];
            int ix = 0;
            foreach (char c in s) 
            {
                charArray[ix++] = c;
                charArray[ix++] = c;
            }
            return new String(charArray);
        }

        public static int CountChars(String s, char c)
        {
            return s.Count(charInString => charInString == c);
        }

        public static long SumDigits(String s)
        {
            return s.Where(charInString => charInString > '0' && charInString <= '9')
                .Select(charVal => charVal - '0')
                .Sum();
        }

        public static long SumNumbers(String s)
        {
            String[] numbers = Regex.Split(s, "[^.0-9]");
            return numbers.Where(stringVal => stringVal != "")
                .Select(stringVal => Int32.Parse(stringVal))
                .Sum();
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1.Length != s2.Length) return false;
            foreach(char s1Char in s1)
            {
                int matchingIx = s2.IndexOf(s1Char);
                if (matchingIx < 0)
                {
                    return false;
                }
                else
                {
                    s2 = s2.Remove(matchingIx, 1);
                }
            }
            return true;
        }

        public static int BlackJack(int count1, int count2)
        {
            var counts = new List<int>();
            counts.Add(count1);
            counts.Add(count2);
            return NPlayerBlackJack(counts);
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            var counts = new List<int>();
            counts.Add(count1);
            counts.Add(count2);
            counts.Add(count3);
            counts.Add(count4);
            counts.Add(count5);
            return NPlayerBlackJack(counts);
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            IEnumerable<int> validHands = counts.Where(val => val <= 21 && val >= 0);
            
            return validHands.Count() > 0 ? validHands.Max() : 0;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            var dictionary = new Dictionary<String, int>();
            foreach(String word in arr)
            {
                int currentCount;
                dictionary.TryGetValue(word, out currentCount);
                dictionary[word] = currentCount + 1;
            }
            return dictionary;
        }

        public static int Factorial(int n)
        {
            if (n <= 0) return 1;
            return n * Factorial(n - 1);
        }

        public static List<String> FB(int n)
        {
            var output = new List<String>();
            for (int i = 1; i <= n; i++)
            {
                String thisString = "";
                if (i % 3 == 0)
                {
                    thisString += "Fizz";
                }
                if (i % 5 == 0)
                {
                    thisString += "Buzz";
                }
                if (thisString.Length == 0)
                {
                    thisString = i.ToString();
                }
                output.Add(thisString);
            }
            return output;
        }
    }
}

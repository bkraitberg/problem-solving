namespace problem_solving
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static int Vector { get; private set; }

        static void Main(string[] args)
        {
        }

        public static long SumArray(IEnumerable<int> arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");
            
            long result = 0;
            foreach (int i in arr)
            {
                result += i;
            }

            return result;

        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");

            long result = 0;
            foreach (int i in arr)
            {
                if (Math.Abs(i % 2) == 1)
                {
                    result += i;
                }
            }

            return result;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");

            long result = 0;
            IEnumerator<int> enumerator = arr.GetEnumerator();
            
            while (enumerator.MoveNext() && enumerator.MoveNext())
            {
                result += enumerator.Current;
            }

            return result;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");
            Dictionary<int, bool> values = GetDictionaryForArray(arr);

            return values.Keys;
        }

        private static Dictionary<int, bool> GetDictionaryForArray(IEnumerable<int> arr)
        {
            Dictionary<int, bool> values = new Dictionary<int, bool>();

            foreach (int i in arr)
            {
                values[i] = true;
            }

            return values;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null) throw new ArgumentNullException("arrA");
            if (arrB == null) throw new ArgumentNullException("arrB");

            return arrA.Intersect(arrB).ToArray();
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null) throw new ArgumentNullException("arrA");
            if (arrB == null) throw new ArgumentNullException("arrB");

            Dictionary<int, bool> values = new Dictionary<int, bool>();

            foreach (int i in arrA)
            {
                values[i] = true;
            }

            foreach (int i in arrB)
            {
                if (!values.ContainsKey(i))
                    values[i] = true;
                else
                    values[i] = false;
            }

            return values.Keys.Where(key=>values[key]);
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (arr == null) throw new NullReferenceException("arr");
            if (arr.Count() == 1) return false;
            
            return HasSumMethod1_BigONSquared(arr, target);
        }

        private static bool HasSumMethod1_BigONSquared(IEnumerable<int> arr, long target)
        {
            int ix = 0;
            foreach (int i in arr)
            {
                int jx = 0;
                foreach (int j in arr)
                {
                    if ((ix != jx) && (i + j == target))
                    {
                        return true;
                    }

                    ++jx;
                }

                ++ix;
            }

            return false;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");

            Dictionary<int, bool> nonDuplicateValues = new Dictionary<int, bool>();

            foreach (int i in arr)
            {
                if (!nonDuplicateValues.ContainsKey(i))
                {
                    nonDuplicateValues[i] = true;
                }
                else
                {
                    nonDuplicateValues[i] = false;
                }
            }

            return nonDuplicateValues.Keys.Where(key=>nonDuplicateValues[key]).Sum();
        }

        public static String DoubleString(String s)
        {
            if (s == null) throw new ArgumentNullException("s");

            StringBuilder sb = new StringBuilder(s.Length * 2);

            foreach (char c in s)
            {
                sb.Append(c);
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static int CountChars(String s, char c)
        {
            if (s == null) throw new ArgumentNullException("s");

            int result = 0;

            foreach (char sc in s)
            {
                if (sc == c)
                    result++;
            }

            return result;
        }

        public static long SumDigits(String s)
        {
            if (s == null) throw new ArgumentNullException("s");

            int result = 0;

            foreach (char c in s)
            {
                byte digit;
                if (byte.TryParse(c.ToString(), out digit))
                    result += digit;
            }

            return result;
        }

        public static long SumNumbers(String s)
        {
            if (s == null) throw new ArgumentNullException("s");
            
            long result = 0;
            long? currentNumber = null;

            foreach (char c in s)
            {
                byte currentDigit;

                if (byte.TryParse(c.ToString(), out currentDigit))
                {
                    if (currentNumber.HasValue)
                    {
                        currentNumber *= 10;
                        currentNumber += currentDigit;
                    }
                    else
                    {
                        currentNumber = currentDigit;
                    }
                }
                else
                {
                    if (currentNumber.HasValue)
                    {
                        result += currentNumber.Value;
                        currentNumber = null;
                    }
                }
            }


            if (currentNumber.HasValue)
            {
                result += currentNumber.Value;
                currentNumber = null;
            }

            return result;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1 == null) throw new NullReferenceException("s1");
            if (s2 == null) throw new NullReferenceException("s2");
            
            if (s1.Length != s2.Length)
                return false;
            else
                return new string(s1.OrderBy(c => c).ToArray()) == new string(s2.OrderBy(c => c).ToArray());
        }

        public static int BlackJack(int count1, int count2)
        {
            return NPlayerBlackJack(new int[] { count1, count2 });
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            return NPlayerBlackJack(new int[] { count1, count2, count3, count4, count5 });
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            if (counts == null) throw new ArgumentNullException("counts");

            int currentlyClosest = 0;
            foreach (int i in counts)
            {
                if (i <= 21)
                {
                    currentlyClosest = Math.Max(currentlyClosest, i);
                }
            }

            return currentlyClosest;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            if (arr == null) throw new NullReferenceException("arr");

            Dictionary<String, int> dictionary = new Dictionary<string, int>();
            foreach (string word in arr)
            {
                if (!dictionary.ContainsKey(word))
                    dictionary[word] = 1;
                else
                    dictionary[word] += 1;
            }

            return dictionary;
        }

        public static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        private static bool IsDivisibleBy3(int n)
        {
            return n % 3 == 0;
        }

        private static bool IsDivisibleBy5(int n)
        {
            return n % 5 == 0;
        }

        public static List<String> FB(int n)
        {
            List<String> results = new List<string>(n);

            for (int i = 1; i <= n; ++i)
            {
                bool isMultipleOf3 = IsDivisibleBy3(i);
                bool isMultipleOf5 = IsDivisibleBy5(i);

                if (isMultipleOf3 && isMultipleOf5)
                    results.Add("FizzBuzz");
                else if (isMultipleOf3)
                    results.Add("Fizz");
                else if (isMultipleOf5)
                    results.Add("Buzz");
                else
                    results.Add(i.ToString());
            }

            return results;
        }
    }
}

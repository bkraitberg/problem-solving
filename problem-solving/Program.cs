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
                throw new ArgumentNullException();

            long sum = 0;

            foreach (int value in arr)
            {
                sum += value;
            }

            return sum;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            long sum = 0;

            foreach (int value in arr)
            {
                if (value % 2 != 0)
                {
                    sum += value;
                }
            }

            return sum;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            long sum = 0;
            int count = 0;

            foreach (int value in arr)
            {
                count++;
                if (count % 2 == 0)
                {
                    sum += value;
                }
            }

            return sum;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            List<int> uniqueValuesArray = new List<int>();

            if (arr == null)
                throw new ArgumentNullException();

            foreach (int value in arr)
            {
                if (!uniqueValuesArray.Contains(value))
                {
                    uniqueValuesArray.Add(value);
                }
            }

            return uniqueValuesArray;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            // TODO
            if (arrA == null || arrB == null)
                throw new ArgumentNullException();

            List<int> intersectArray = new List<int>();

            foreach (int valueA in arrA)
            {
                foreach (int valueB in arrB)
                {
                    if (valueA == valueB && !intersectArray.Contains(valueA))
                    {
                        intersectArray.Add(valueA);
                        break;
                    }
                }
            }

            return intersectArray;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null || arrB == null)
                throw new ArgumentNullException();
            List<int> listArrA = new List<int>(arrA);
            List<int> listArrB = new List<int>(arrB);
            List<int> notIntersectArray = new List<int>();

            foreach (int valueA in listArrA)
            {
                if (!listArrB.Contains(valueA))
                {
                    notIntersectArray.Add(valueA);
                }
            }

            foreach (int valueB in listArrB)
            {
                if (!listArrA.Contains(valueB))
                {
                    notIntersectArray.Add(valueB);
                }
            }
            
            return notIntersectArray;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if(arr == null || target == null)
                throw new NullReferenceException();

            bool hasSum = false;
            int[] array = arr.ToArray();
            int count = 1;

            for(int a = 0; a < array.Length; a++)
            {
                for (int i = count; i < array.Length; i++)
                {
                    if (a != i)
                    {
                        if (array[a] + array[i] == target)
                        {
                            hasSum = true;
                            break;
                        }
                    }
                }

                if (hasSum)
                    break;
            }

            return hasSum;
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            if (arr == null)
                throw new ArgumentNullException();

            Dictionary<int, int> arrayValues = new Dictionary<int, int>();

            long sum = 0;

            foreach (int value in arr)
            {
                if (!arrayValues.ContainsKey(value))
                {
                    arrayValues.Add(value, 1);
                    sum += value;
                }
                else
                {
                    if (arrayValues[value] == 1)
                    {
                        sum -= value;
                    }

                    arrayValues[value]++;
                }
            }

            return sum;
        }

        public static String DoubleString(String s)
        {
            string returnString = string.Empty;

            if (s != null)
            {
                foreach (char sChar in s)
                {
                    returnString += sChar + "" + sChar;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return returnString;
        }

        public static int CountChars(String s, char c)
        {
            int charCount = 0;

            if (s != null)
            {
                foreach (char sChar in s)
                {
                    if (sChar == c)
                        charCount++;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return charCount;
        }

        public static long SumDigits(String s)
        {
            if (s == null)
                throw new ArgumentNullException();

            long sum = 0;

            foreach (char sChar in s)
            {
                int parsedChar;

                if(Int32.TryParse(sChar.ToString(), out parsedChar))
                {
                    sum += parsedChar;
                }
            }

            return sum;
        }

        public static long SumNumbers(String s)
        {
            if (s == null)
                throw new ArgumentNullException();

            long sum = 0;
            int parsedChar;
            string currentNumber = string.Empty;
            
            foreach (char sChar in s)
            {
                if (Int32.TryParse(sChar.ToString(), out parsedChar))
                {
                    currentNumber += "" + sChar;
                }
                else
                {
                    if (currentNumber != string.Empty)
                    {
                        sum += Int32.Parse(currentNumber);
                        currentNumber = string.Empty;
                    }
                }
            }

            if (currentNumber != string.Empty)
            {
                sum += Int32.Parse(currentNumber);
                currentNumber = string.Empty;
            }

            return sum;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1 == null || s2 == null)
                throw new NullReferenceException();

            char[] sortedArrayOfS1 = s1.ToArray();
            char[] sortedArrayOfS2 = s2.ToArray();

            Array.Sort(sortedArrayOfS1);
            Array.Sort(sortedArrayOfS2);

            s1 = new String(sortedArrayOfS1);
            s2 = new String(sortedArrayOfS2);

            return s1.Equals(s2);
        }

        public static int BlackJack(int count1, int count2)
        {
            int returnValue;
            const int Twenty_One = 21;

            if (count1 > Twenty_One && count2 > Twenty_One)
            {
                returnValue = 0;
            }
            else if(count1 > Twenty_One)
            {
                returnValue = count2;
            }
            else if (count2 > Twenty_One)
            {
                returnValue = count1;
            }
            else if (count1 > count2)
            {
                returnValue = count1;
            }
            else
            {
                returnValue = count2;
            }

            return returnValue;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            int returnValue;
            const int Twenty_One = 21;
            int[] values = new int[] { count1, count2, count3, count4, count5 };

            if (count1 > Twenty_One && count2 > Twenty_One && count3 > Twenty_One && count4 > Twenty_One && count5 > Twenty_One)
            {
                returnValue = 0;
            }
            else
            {
                if (values[0] <= 21)
                    returnValue = values[0];
                else
                    returnValue = 0;

                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] > values[i - 1] && values[i] > returnValue && values[i] <= Twenty_One)
                    {
                        returnValue = values[i];
                    }
                }
            }
            return returnValue;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            if (counts == null)
                throw new ArgumentNullException();

            int returnValue = 0;
            const int Twenty_One = 21;
            int[] values = counts.ToArray();

            if (values.Length == 0 || values[0] > 21)
                returnValue = 0;
            else
                returnValue = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                if (returnValue == 0 && values[i] > 21)
                {
                    returnValue = 0;
                }
                else
                {
                    if (values[i] > values[i - 1] && values[i] > returnValue && values[i] <= Twenty_One)
                    {
                        returnValue = values[i];
                    }
                }
            }

            return returnValue;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            Dictionary<string, int> stringCount = new Dictionary<string, int>();

            foreach (String strValue in arr)
            {
                if (!stringCount.ContainsKey(strValue))
                {
                    stringCount.Add(strValue, 1);
                }
                else
                {
                    stringCount[strValue]++;
                }
            }

            return stringCount ;
        }

        public static long Factorial(int n)
        {
            long sum = n;

            if (n > 0)
            {
                for (int i = n - 1; i > 1; i--)
                {
                    sum = sum * i;
                }
            }
            else
            {
                sum = 1;
            }

            return sum;
        }

        public static List<String> FB(int n)
        {
            List<String> returnString = new List<string>();
            const string divisibleBy3 = "Fizz";
            const string divisibleBy5 = "Buzz";
            const string divisibleBy3And5 = "FizzBuzz";

            for(int i=1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    returnString.Add(divisibleBy3And5);
                }
                else if (i % 3 == 0)
                {
                    returnString.Add(divisibleBy3);
                }
                else if (i % 5 == 0)
                {
                    returnString.Add(divisibleBy5);
                }
                else
                {
                    returnString.Add(""+i);
                }
            }

            return returnString;
        }
    }
}

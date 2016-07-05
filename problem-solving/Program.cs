using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
            long sumValue = 0;
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                foreach (int value in arr)
                {
                    sumValue += value;
                }
            }
            
            return sumValue;
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            // return the sum of all the values in the array that are odd
            // TODO
            IList<int> oddList = new List<int>();

            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            else 
            { 
                foreach (int oddValue in arr)
                {
                    if (oddValue%2 != 0)
                    {
                        oddList.Add(oddValue);
                    }
                }
            }
            return Convert.ToInt64(oddList.Sum());
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            // return the sum of every second value in the array. i.e. the 2nd value + the 4th value + the 6th value ...
            // TODO
            IList<int> oddList = new List<int>();

            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                foreach (var vItem in arr.Select((iValue, iIndex) => new{Index = iIndex, Value = iValue}))
                {
                    if ((vItem.Index+1)%2 == 0)
                        {
                            oddList.Add(vItem.Value);
                        }
                }
            }
            return Convert.ToInt64(oddList.Sum());
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            // return an array that contains only unique values from the passed in array
            // TODO
            var uniqueItem = arr.Distinct();

            return uniqueItem;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A and array B
            // TODO
            IEnumerable<int> inBothArr;
            if (arrA == null || arrB == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                inBothArr = arrA.Intersect(arrB).ToArray();
            }
            return inBothArr;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            // return an array that contains all the values that are in array A or array B but not in both array A and array B
            // TODO


            IEnumerable<int> intUnionArr;
            IEnumerable<int> intInterceptArr;
            IEnumerable<int> intNotInBothArr;

            if (arrA == null && arrB == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                intUnionArr = arrA.Union(arrB).ToArray();
                intInterceptArr = GetArrayIntersect(arrA, arrB);
                intNotInBothArr = intUnionArr.Except(intInterceptArr);
            }
            return intNotInBothArr;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            // return true if any 2 values in the array have a sum equal to the target value
            // TODO
            bool? sumEqualToTarget = null;

            if (arr == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                int inext = 0; 
    
                for (int i=0; i < arr.Count(); i++)
                {
                    for (int j = i+1; j < arr.Count() ; j++)
                    {
                        if (Convert.ToInt64(arr.ElementAt(i) + arr.ElementAt(j)) == target)
                        {
                            sumEqualToTarget = true;
                            break;
                        }
                    }
                }
            }

            return (sumEqualToTarget ?? false);
        }

        public static long LoneSum(IEnumerable<int> arr)
        {
            // Given an array of int values, return their sum. 
            // However, if any of the values is the same as another of the values, it does not count towards the sum.

            long lSum = 0;
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                bool bskip = false;
              
                // foreach (var vItem in arr.Select(  (iValue, iIndex) => new { Value = iValue, Index = iIndex } ) )
                for (int i = 0; i < arr.Count(); i++)
                {
                    int j = 0;
                    do
                    {
                        
                        if ((arr.ElementAt(i) == arr.ElementAt(j)) && (i != j))
                        {
                            bskip = true;
                        }

                       
                        j++;
                        
                    } while (j < arr.Count());

                    if (bskip == true)
                        bskip = false;
                    else
                    {
                        lSum += Convert.ToInt64(arr.ElementAt(i));
                    }
                }
            }
            return (lSum);
        }

        public static String DoubleString(String s)
        {

            // return a string that is the original string with each character in the string repeated twice
            // e.g. for input "ABCDE", return "AABBCCDDEE"
            string sDoubleString;

            if (s == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var newstring = from ch in s
                                select ch;

                var sb = new StringBuilder();

                foreach (var c in newstring)
                    sb.Append(c.ToString() + c.ToString());
                sDoubleString = sb.ToString();
            }

            return sDoubleString;
        }

        public static int CountChars(String s, char c)
        {
            // return the count of how many times char c occurs in string s
            int iCount = 0;
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            else
            {

                foreach (char ch in s)
                {
                    if (ch.Equals(c))
                    {
                        iCount++;
                    }
                }

            }

            return iCount;
        }

        public static long SumDigits(String s)
        {
            // return the sum of the digits 0-9 that appear in the string, ignoring all other characters
            // e.g. "123" return 6
            long lsum = 0;
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            else
            {

                foreach (char ch in s)
                {
                   
                    if (char.IsDigit(ch))
                    {
                        lsum += Int64.Parse(ch.ToString());
                    }
                }
             }

            return lsum;
        }

        public static long SumNumbers(String s)
        {
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            long lsum = 0;

            if (s == null)
            {
                throw new ArgumentNullException();
            }
            else
            {

                String sOrigStr = Regex.Replace(s, "[^0-9]", " ");
                String sDigit = string.Empty;
                long l1 = 0;
                Boolean lbAdd = false;


                for (int i = 0; i < sOrigStr.Length; i++)
                {
                    if (char.IsDigit(sOrigStr[i]))
                    {
                        sDigit += sOrigStr[i];

                        if (i == sOrigStr.Length -1)
                            lbAdd = true;
                    }

                    else
                    {
                        
                       if (char.IsWhiteSpace(sOrigStr[i].ToString(), 0))
                       {
                           lbAdd = true;
                       }
                    }

                    if (lbAdd == true)
                    {
                        if (sDigit.Length > 0)
                            {
                                l1 = Int64.Parse(sDigit);
                                lsum += l1;
                                //reset
                                sDigit = string.Empty;
                                l1 = 0;
                            }
                        
                        lbAdd = false;
                     
                    }
                }
            }
            return lsum;
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            // return true if String s1 is an anagram of s2, otherwise return false
            // An anagram is produced by rearranging the letters of one string into another
            // e.g. care is an anagram of race
            // cat is not an anagram of rat
            Boolean bIsAnagram = false;
            Boolean lbArrange = false;
            int iMatchedCnt = 0;

            if (s1 == null && s2 == null)
            {
                throw new NullReferenceException();
                bIsAnagram = true;
            }
            else if (s1.Length == 0 && s2.Length == 0)
                bIsAnagram = true;

            else if ((s1 == null && (s2 != null)) || (s1 != null && s2 == null))
                bIsAnagram = false;
            else
            {
                if (s1.Length == s2.Length && s1.Length > 0 && s2.Length > 0)
                    lbArrange = true;
                else
                {
                    bIsAnagram = false;
                }
            }

            if (lbArrange == true && bIsAnagram != true)
            {
                for (int i = 0; i < s1.Length; i++)
                {

                    foreach (char chsrchloop in s2)
                        if (s1[i].Equals(chsrchloop))
                    {
                        iMatchedCnt++;
                        break;
                    }
                }

                if (iMatchedCnt > 0 && (iMatchedCnt == s1.Length))
                {
                    bIsAnagram = true;
                }
            }

           

            return bIsAnagram;
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            int iResult = 0;
            int iBJ = 21;
            List<int> bj = new List<int>();
            int maxVal = 0;
            int overCount = 0;
            IEnumerable<int> arr = new int[] { count1, count2 };

            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr.ElementAt(i) > iBJ)
                {
                    overCount++;
                }
            }

            if (overCount == arr.Count())
                iResult = 0;
            else
            {


                for (int i = 0; i < arr.Count(); i++)
                {
                    if (arr.ElementAt(i) <= iBJ)
                    {

                        bj.Add(arr.ElementAt(i));

                    }
                }

                if (bj.Count > 0)
                {
                    maxVal = bj.ElementAt(0);
                    for (int i = 1; i < bj.Count; i++)
                        if (bj.ElementAt(i) > maxVal)
                        {
                            maxVal = bj.ElementAt(i);
                        }
                    iResult = maxVal;
                }
            }

            return iResult;
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            // Given 5 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            int iResult = 0;
            int iBJ = 21;
            List<int> bj = new List<int>();
            int maxVal = 0;
            int overCount = 0;
            IEnumerable<int> arr = new int[] { count1, count2, count3, count4, count5 };

            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr.ElementAt(i) > iBJ)
                {
                    overCount++;
                }
            }

            if (overCount == arr.Count())
                iResult = 0;
            else
            {


                for (int i = 0; i < arr.Count(); i++)
                {
                    if (arr.ElementAt(i) <= iBJ)
                    {

                        bj.Add(arr.ElementAt(i));

                    }
                }

                if (bj.Count > 0)
                {
                    maxVal = bj.ElementAt(0);
                    for (int i = 1; i < bj.Count; i++)
                        if (bj.ElementAt(i) > maxVal)
                        {
                            maxVal = bj.ElementAt(i);
                        }
                    iResult = maxVal;
                }
            }

            return iResult;
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {
            // Given a list of integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they all go over.
            int iResult = 0;
            int iBJ = 21;
            List<int> bj = new List<int>();
            int maxVal = 0;
            int overCount = 0;

            if (counts == null)
            {
                throw new ArgumentNullException();
                
            }
            else if (counts.Count() == 0)
                iResult = 0;
            else
            {

                for (int i = 0; i < counts.Count(); i++)
                {
                    if (counts.ElementAt(i) > iBJ)
                    {
                        overCount++;
                    }
                }

                if (overCount == counts.Count())
                    iResult = 0;
                else
                {


                    for (int i = 0; i < counts.Count(); i++)
                    {
                        if (counts.ElementAt(i) <= iBJ)
                        {

                            bj.Add(counts.ElementAt(i));

                        }
                    }

                    if (bj.Count > 0)
                    {
                        maxVal = bj.ElementAt(0);
                        for (int i = 1; i < bj.Count; i++)
                            if (bj.ElementAt(i) > maxVal)
                            {
                                maxVal = bj.ElementAt(i);
                            }
                        iResult = maxVal;
                    }
                }
            }
            return iResult;
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int cnt = 0;
            if (arr == null)
                throw new NullReferenceException();
            else
            {
               var arrDistinct = arr.Distinct();

                for (int i = 0; i < arrDistinct.Count(); i++)
                {
                    for (int j = 0; j < arr.Count(); j++)
                        if (arrDistinct.ElementAt(i) == arr.ElementAt(j))
                            cnt++;

                    dict.Add(arrDistinct.ElementAt(i),cnt);
                    //reset count
                    cnt = 0;
                }
            }

            return dict;
        }

        public static int Factorial(int n)
        {
            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            int ireturn = 0;
            if (n <= 1)
                ireturn = 1;
            else
            {
                ireturn =n *  Factorial(n - 1);
            }
            return ireturn;
        }

        public static List<String> FB(int n)
        {
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            String lsValue;
            bool lbThree = false;
            bool lbFive = false;
            List<String> lstrList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int j = i + 1;

                if (j % 3 == 0)
                    lbThree = true;
                
                if (j % 5 == 0)
                    lbFive = true;

                if (lbThree == true && lbFive ==true)
                    lstrList.Add("FizzBuzz");
                else if (lbThree == true)
                    lstrList.Add("Fizz");
                else if (lbFive == true)
                    lstrList.Add("Buzz");
                else
                {
                    lstrList.Add(j.ToString());
                }

                //reset
                lbThree = false;
                lbFive = false;
            }


            return lstrList;
        }
    }
}

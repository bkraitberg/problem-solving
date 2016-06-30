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

            List<Int64> bigints = new List<Int64>();
            foreach (int val in arr)
            {
                bigints.Add(val);
            }
            return bigints.Sum();
        }

        public static long SumArrayOddValues(IEnumerable<int> arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException();
            }

            var scooby = 0;
            foreach(int val in arr)
            {
                if(val % 2 != 0)
                {
                    scooby = scooby + val;
                }
            }
            return scooby;
        }

        public static long SumArrayEverySecondValue(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            var scooby = 0;
            var skipOdd = 0;
            foreach (int val in arr)
            {
                skipOdd++;
                if (skipOdd % 2 == 0)
                {
                    scooby = scooby + val;
                }
            }
            return scooby;
        }

        public static IEnumerable<int> GetUniqueValues(IEnumerable<int> arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<int> SoUniqueMuchValues = new List<int>();
            SoUniqueMuchValues = arr.ToList<int>().Distinct<int>();
            return SoUniqueMuchValues;
        }

        public static IEnumerable<int> GetArrayIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null || arrB == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<int> crissCross = arrA.Intersect(arrB);
            return crissCross;
        }

        public static IEnumerable<int> GetArrayNotIntersect(IEnumerable<int> arrA, IEnumerable<int> arrB)
        {
            if (arrA == null || arrB == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<int> divergent = arrA.Except(arrB).Union(arrB.Except(arrA));
            return divergent;
        }

        public static Boolean HasSum(IEnumerable<int> arr, long target)
        {
            if (target == null)
            {
                throw new ArgumentNullException();
            }

            var index = 0;
            foreach(int val in arr)
            {
                index++;
                var remainingList = arr.Skip(index).ToList<int>();
                var searchValue = Convert.ToInt32(target - val);
                if (remainingList.Contains(searchValue))
                {
                    return true;
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
            var newDupes = new List<int>();
            foreach (int val in arr)
            {
                var testList = arr.ToList<int>().FindAll(x => x.Equals(val));
                if(testList.Count == 1)
                {
                    newDupes.Add(val);
                }
                
            }

            return SumArray(newDupes);
        }

        public static String DoubleString(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            var retValu = "";

            if (s.Length > 0)
            {
                foreach (char c in s.ToArray())
                {
                    retValu = retValu + c.ToString() + c.ToString();
                }
            }

            return retValu;
        }

        public static int CountChars(String s, char c)
        {
            if (s == null || c == null)
            {
                throw new ArgumentNullException();
            }
            var testList = s.ToList().FindAll(x => x.Equals(c));
            return testList.Count;
        }

        public static long SumDigits(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            var numNumNum = new List<int>();

            foreach (char c in s.ToArray())
            {                
                int number = 0;
                if(int.TryParse(c.ToString(),out number))                
                {
                    numNumNum.Add(number);
                }    
            }

            return SumArray(numNumNum);
        }

        public static long SumNumbers(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            var longCount = new List<int>();
            string toAdd = "";
            // return the sum of the numbers that appear in the string, ignoring all other characters
            // a number is a series of 1 or more digits in a row
            // e.g. "11 22" returns 33
            foreach (char c in s.ToArray())
            {
                int number = 0;
                
                if (int.TryParse(c.ToString(), out number))
                {
                    toAdd = toAdd + c.ToString();
                }
                else
                {
                    if (toAdd.Length > 0)
                    {
                        longCount.Add(int.Parse(toAdd));
                        toAdd = "";
                    }
                }
            }
            if (toAdd.Length > 0)
            {
                longCount.Add(int.Parse(toAdd));
            }


            return SumArray(longCount);
        }

        public static Boolean IsAnagram(String s1, String s2)
        {
            if (s1 == null || s2 == null)
            {
                throw new NullReferenceException();
            }

            if(s1.Length != s2.Length)
            {
                return false;
            }

            var arrayOfString = s2.ToList();

            foreach(char c in s1.ToArray())
            {
                var index = arrayOfString.IndexOf(c);
                if(index >= 0)
                {
                    arrayOfString.RemoveAt(index);
                }
            }

            if (arrayOfString.Count == 0)
            {
                return true;
            }
            
            return false;
        }

        public static int BlackJack(int count1, int count2)
        {
            // Given 2 integer values greater than 0, 
            // return whichever value is nearest to 21 without going over. 
            // Return 0 if they both go over.
            if (count1 == null || count2 == null)
            {
                throw new ArgumentNullException();
            }
            var retval = 0;

            retval = count1 > 21? 
                (count2 > 21? 
                    0 : count2)
                :(count2 > 21?
                    count1: (count1 >= count2 ?
                                    count1:count2));


            return retval; 
        }

        public static int FivePlayerBlackJack(int count1, int count2, int count3, int count4, int count5)
        {
            var players = new List<int>();
            if (count1 <= 21) players.Add(count1);
            if (count2 <= 21) players.Add(count2);
            if (count3 <= 21) players.Add(count3);
            if (count4 <= 21) players.Add(count4);
            if (count5 <= 21) players.Add(count5);

            if (players.Count == 0) return 0;

            var ordered = players.OrderByDescending(x => x);

            return ordered.First();
        }

        public static int NPlayerBlackJack(IEnumerable<int> counts)
        {

            if (counts == null)
            {
                throw new ArgumentNullException();
            }

            var players = new List<int>();
            foreach(int val in counts)
            {
                if (val <= 21) players.Add(val);
            }
            if (players.Count == 0) return 0;

            var ordered = players.OrderByDescending(x => x);

            return ordered.First();
        }

        public static Dictionary<String, int> WordCount(IEnumerable<String> arr)
        {
            if (arr == null)
            {
                throw new NullReferenceException();
            }
            // Given an array of Strings, 
            // return a dictionary keyed on the string with the count of how many times each string appears in the array

            var keyMan = new Dictionary<string, int>();
            List<string> workArr = arr.ToList<string>();

            foreach (string wordUp in arr)
            {
                var testList = workArr.ToList().FindAll(x => x.Equals(wordUp));
                if (testList.Count > 0)
                { 
                    keyMan.Add(wordUp, testList.Count);
                    workArr.RemoveAll(x => x == wordUp);
                }
            }
            return keyMan;
        }

        public static int Factorial(int n)
        {
            if (n == null)
            {
                throw new ArgumentNullException();
            }
            var retVal = n;

            if (n <= 1) retVal = 1;
            else
            {
                for (int i = 1; i < n; i++)
                {
                    retVal = retVal * i;
                }
            }

            // Given n, return the factorial of n, which is n * (n-1) * (n-2) ... 1
            return retVal;
        }

        public static List<String> FB(int n)
        {
            if (n == null)
            {
                throw new ArgumentNullException();
            }
            // Given n, print the numbers from 1 to n as a string to a List of strings, with the following exceptions:
            // If the number is divisable by 3, replace it with the word "Fizz"
            // If the number is divisable by 5, replace it with the word "Buzz"
            // If the number is divisable by both 3 and 5, replace it with the word "FizzBuzz"
            var threeAndFives = new List<String>();

            for (int i = 1; i <= n; i++)
            {
                var num = i.ToString();
                if(i%3 == 0)
                {
                    num = "Fizz";
                }
                if (i % 5 == 0)
                {
                    num = "Buzz";
                }
                if ((i % 3 == 0) && (i%5==0))
                {
                    num = "FizzBuzz";
                }
                threeAndFives.Add(num);
            }



            return threeAndFives;
        }
    }
}

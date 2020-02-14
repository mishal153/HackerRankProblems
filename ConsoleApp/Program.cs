using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run_FINDNUMBER();
            //Run_tracesAreSimilar();
            //Run_HourglassSum();
            Run_countingValleys();
        }

        private static void Run_countingValleys()
        {
            var reader = new StreamReader("countingValleys/input/input01.txt");
            Console.SetIn(reader);
            var numberOfSteps = Int32.Parse(Console.ReadLine());
            var sequence = Console.ReadLine();
            var numberOfValleys = countingValleys(numberOfSteps, sequence);
        }

        static int countingValleys(int numberOfSteps, string sequence)
        {
            int currentHeight = 0;
            bool inValley = false;
            int valleyCount = 0;

            foreach(char c in sequence)
            {
                if ( c == 'U')
                {
                    currentHeight++;
                }
                else
                {
                    currentHeight--;
                }

                if (currentHeight < 0 && inValley == false)
                {
                    inValley = true;
                }

                if (inValley == true && currentHeight >= 0)
                {
                    inValley = false;
                    valleyCount++;
                }
            }

            return valleyCount;
        }
        private static void Run_HourglassSum()
        {
            //https://www.hackerrank.com/challenges/2d-array/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

            var reader = new StreamReader("hourglassSum/input/input00.txt");
            Console.SetIn(reader);
            int[][] arr = new int[6][];

            for (var i = 0; i < 6; i++)
            {
                var line = Console.ReadLine();
                arr[i] = Array.ConvertAll(line.Split(' '), c => Int32.Parse(c));
            }
            var maxSum = hourglassSum(arr);
        }

        static int hourglassSum(int[][] arr)
        {
            List<int> sums = new List<int>();

            for (var x = 0; x <= 3; x++)
            {
                for (var y = 0; y <= 3; y++)
                {
                    int[,] indexes = new int[7, 2]
                    {
                        { x, y },
                        { x, y+1 },
                        { x, y+2 },
                        { x+1, y+1 },
                        { x+2, y },
                        { x+2, y+1 },
                        { x+2, y+2 },
                    };
                    var sum = 0;
                    for(var row = 0; row < 7; row++)
                    {
                        var idx = indexes[row, 0];
                        var idy = indexes[row, 1];
                        sum += arr[idx][idy];
                    }
                    sums.Add(sum);
                }
            }

            return sums.Max();
        }


        private static void Run_frequencyCount()
        {
            var reader = new StreamReader("./in.txt");
            Console.SetIn(reader);
            // 1-a,2-b,3,4,5,6,7,8,9-i
            // 
            var sample1 = "1226&24&";
            var r = frequencyCount(sample1);
        }

        public static List<int> frequencyCount(string s)
        {
            throw new System.InvalidProgramException();
            var results = new List<int>(26);
            string reduced = string.Empty;
            // find t-z
            {
                int val = -1, count = 1;
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '&')
                    {
                        val = int.Parse($"{s[i - 2]}{s[i - 1]}");
                    }
                    if (s[i + 1] == '[')
                    {
                        count = int.Parse($"{s[i + 2]}");
                    }
                }

                if (val > 0)
                {
                    results[val] = count;
                }
            }

            // find j - s
            {
                int val = -1, count = 1;
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '&')
                    {
                        val = int.Parse($"{s[i - 2]}{s[i - 1]}");
                    }
                    if (s[i + 1] == '[')
                    {
                        count = int.Parse($"{s[i + 2]}");
                    }
                }

                if (val > 0)
                {
                    results[val] = count;
                }
            }

            // find a-i


        }

        private static void Run_tracesAreSimilar()
        {
            var reader = new StreamReader("./in.txt");
            Console.SetIn(reader);

            var s = new List<int>
            {
                10,10,20,10,10,20
            };
            var t = new List<int>
            {
                20,20,10,20,20,30
            };
            var result = tracesAreSimilar(s, t);
        }

        public static string tracesAreSimilar(List<int> s, List<int> t)
        {
            Func<List<int>, List<int>, int, Boolean> validation = (s1, t1, val) =>
            {
                var s1Count = s1.Count(v => v == val);
                var t1Count = t1.Count(v => v == val);

                if (Math.Abs(s1Count - t1Count) > 3)
                {
                    return false;
                }

                return true;
            };

            const string ResultYes = "YES", ResultNo = "NO";
            //int sCount = 0, tCount = 0;

            if (s == null || t == null || s.Count == 0 || t.Count == 0 || s.Count != t.Count)
            {
                return ResultNo;
            }

            var distinctValues = s.Concat(t).Distinct().ToList();
            Console.Write($"{distinctValues.Count} distinct values");
            List<System.Threading.Tasks.Task<bool>> tasks = new List<System.Threading.Tasks.Task<bool>>();
            foreach (var value in distinctValues)
            {
                var aTask = System.Threading.Tasks.Task.Run<bool>(() => validation(s, t, value));
                tasks.Add(aTask);
            }

            System.Threading.Tasks.Task.WhenAll(tasks).Wait();
            var failedTask = tasks.FirstOrDefault(tCompleted => tCompleted.Result == false);
            if (failedTask != null)
            {
                return ResultNo;
            }

            return ResultYes;
        }



        private static void Run_FINDNUMBER()
        {
            var elementCount = Convert.ToInt32(Console.ReadLine());
            List<int> numbers = new List<int>();
            if (elementCount > 0)
            {
                while (elementCount > 0)
                {
                    var number = Convert.ToInt32(Console.ReadLine());
                    numbers.Add(number);
                    elementCount--;
                }
            }

            var numToFind = Convert.ToInt32(Console.ReadLine());

            var result = findNumber(numbers, numToFind);
        }

        public static string findNumber(List<int> arr, int k)
        {
            if (arr == null || arr.Count <= 0)
            {
                return "NO";
            }
            for (var i = 0; i < arr.Count; i++)
            {
                if (arr[i] == k)
                {
                    return "YES";
                }
            }

            return "NO";
        }
    }
}

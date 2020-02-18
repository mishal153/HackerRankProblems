using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.Easy.hourglassSum
{
    public static class HourglassSumRunner
    {
        public static void Run()
        {
            Run_HourglassSum();
        }

        private static void Run_HourglassSum()
        {
            //https://www.hackerrank.com/challenges/2d-array/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays

            var reader = new StreamReader("Easy/hourglassSum/input/input00.txt");
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
                    for (var row = 0; row < 7; row++)
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
    }
}

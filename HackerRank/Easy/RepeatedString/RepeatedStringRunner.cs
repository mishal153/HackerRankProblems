using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace HackerRank.Easy.RepeatedString
{
    public static class RepeatedStringRunner
    {
        public static void Run()
        {
            var reader = new StreamReader("Easy/RepeatedString/input/input00.txt");
            Console.SetIn(reader);

            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            long result = repeatedString(s, n);
        }

        private static long repeatedString(string s, long n)
        {
            int idx = 0;
            var countInFullString = s.Count(c => c == 'a');
            var fullRepetetions = n / s.Length;
            var extraCharacters = n % s.Length;
            var countOfA = fullRepetetions * countInFullString;

            for (var i = 0; i < extraCharacters; i++)
            {
                if (s[i] == 'a')
                    countOfA++;
            }

            return countOfA;
        }
    }
}

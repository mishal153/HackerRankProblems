using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace HackerRank.Easy.JumpingOnTheClouds
{
    public static class JumpingOnTheClouds
    {
        //https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=warmup
        public static void Run()
        {
            var reader = new StreamReader("Easy/JumpingOnTheClouds/input/input01.txt");
            Console.SetIn(reader);
            int n = Convert.ToInt32(Console.ReadLine());
            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = jumpingOnClouds(c);
        }

        private static int jumpingOnClouds(int[] c)
        {
            var maxIdx = c.Length - 1;
            var idx = 0;
            var jumpCount = 0;

            while(idx < maxIdx)
            {
                var bigJumpIdx = idx + 2;
                if (bigJumpIdx <= maxIdx && c[bigJumpIdx] == 0)
                {
                    idx = bigJumpIdx;
                    jumpCount++;
                    continue;
                }

                var smallJumpIdx = idx + 1;
                if (smallJumpIdx <= maxIdx && c[smallJumpIdx] == 0)
                {
                    idx = smallJumpIdx;
                    jumpCount++;
                    continue;
                }
            }

            return jumpCount;
        }
    }
}

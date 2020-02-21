using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRank.Easy.LeftRotation
{
    public static class LeftRotationRunner
    {
        public static void Run()
        {
            var reader = new StreamReader("Easy/LeftRotation/input/input00.txt");
            Console.SetIn(reader);
            string[] nd = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = rotLeft(a, d);
        }

        private static int[] rotLeft(int[] a, int d)
        {
            int[] b = new int[a.Length];
            var idxb = 0;

            for (var i = d; i < a.Length; i++, idxb++)
            {
                b[idxb] = a[i];
            }

            for (var i = 0; i < d; i++, idxb++)
            {
                b[idxb] = a[i];
            }

            return b;
        }
    }
}

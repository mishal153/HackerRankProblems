using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackerRank.Easy.SockMerchant
{
    public static class SockMerchantRunner
    {
        public static void Run()
        {
            var reader = new StreamReader("Easy/SockMerchant/input/input08.txt");
            Console.SetIn(reader);
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = sockMerchant(n, ar);
        }

        private static int sockMerchant(int n, int[] ar)
        {
            var pairs = ar.GroupBy(i => i).Sum(g => g.Count()/2);
            return pairs;
        }
    }
}

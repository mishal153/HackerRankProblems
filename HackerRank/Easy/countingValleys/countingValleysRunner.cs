using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HackerRank.Easy.countingValleys
{
    public static class CountingValleysRunner
    {
        public static void Run()
        {
            Run_countingValleys();
        }
        private static void Run_countingValleys()
        {
            var reader = new StreamReader("Easy/countingValleys/input/input01.txt");
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

            foreach (char c in sequence)
            {
                if (c == 'U')
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

    }
}

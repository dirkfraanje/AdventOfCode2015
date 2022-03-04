using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day2
    {
        readonly static string[] input = System.IO.File.ReadAllLines("DayInputs/Day2.txt");
        public static object Result1()
        {
            int result = 0;
            foreach (var present in input)
            {
                var measurements = present.Split('x').Select(Int32.Parse).ToArray();
                var side1 = measurements[0] * measurements[1];
                var side2 = measurements[0] * measurements[2];
                var side3 = measurements[1] * measurements[2];

                var slack = new List<int>() { side1, side2, side3 }.Min();
                result += 2 * side1 + 2 * side2 + 2 * side3 + slack;
            }
            return result;
        }

        public static object Result2()
        {
            int result = 0;
            foreach (var present in input)
            {
                var measurements = present.Split('x').Select(Int32.Parse).ToArray();
                result += measurements.OrderBy(x => x).Take(2).Sum() * 2 + (measurements[0] * measurements[1] * measurements[2]);
            }
            return result;
        }
    }
}

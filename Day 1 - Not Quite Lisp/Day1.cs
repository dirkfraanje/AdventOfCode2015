using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day1
    {
        readonly static string input = System.IO.File.ReadAllText("DayInputs/day1.txt");
        internal static object Result1()
        {
            return input.Count(x => x == '(') - input.Count(x => x == ')');
        }

        internal static object Result2()
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                var step = input[i];
                if (step == '(')
                    stack.Push(step);
                else
                {
                    if (stack.Count == 0)
                        return i + 1;
                    stack.Pop();
                }
            }
            throw new Exception("Couldn't figure it out");
        }
    }
}

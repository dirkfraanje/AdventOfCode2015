using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2015.Day_08___Matchsticks
{
    internal class Day8
    {
        static int numberOfCodeCharacters;
        static int charactersInMemory;
        static List<string> input = new();
        public static string Result1()
        {
            ParseInput();
            foreach (var line in input)
            {
                var realInput = line.Remove(line.Length - 1, 1).Substring(1);
                string converted = Regex.Unescape(realInput);
                charactersInMemory += converted.Length;
            }
            return $"{numberOfCodeCharacters - charactersInMemory}";
        }

        static void ParseInput()
        {
            foreach (var item in System.IO.File.ReadAllLines("DayInputs/day8.txt"))
            {
                input.Add(item);
                numberOfCodeCharacters += item.Length;
            }
        }
    }
}
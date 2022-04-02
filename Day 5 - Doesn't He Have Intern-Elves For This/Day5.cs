using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day5
    {
        public static object Result1()
        {
            var input = System.IO.File.ReadAllLines("DayInputs/Day5.txt");
            var niceCounter = 0;
            foreach (var line in input)
            {
                if (IsNice(line))
                    niceCounter++;
            }
            return niceCounter;
        }
        public static object Result2()
        {
            var input = System.IO.File.ReadAllLines("DayInputs/Day5.txt");
            var niceCounter = 0;
            foreach (var line in input)
            {
                if (IsNice2(line))
                    niceCounter++;
            }
            return niceCounter;
        }

        private static bool IsNice2(string line)
        {
            var combiCheck = false;
            var repeatCheck = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (i+1 == line.Length)
                    break;
                var combi = $"{line[i]}{line[i+1]}";
                var sub = line.Substring(i + 2);
                if(sub.Contains(combi))
                    combiCheck = true;
                if(i+2 < line.Length)
                {
                    if(line[i+2] == line[i])
                        repeatCheck = true;
                }
            }

            return combiCheck && repeatCheck;
        }

        private static bool IsNice(string line)
        {
            var naughty = new Regex("(?:ab|cd|pq|xy)");
            if (naughty.IsMatch(line))
                return false;

            var doubleCharacter = new Regex("(?<char>\\w)\\k<char>");
            if (!doubleCharacter.IsMatch(line))
                return false;

            var removeVowels = line.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "");
            if (line.Length - removeVowels.Length < 3)
                return false;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day6 : IDayBase
    {
        List<Light> coordinates = new List<Light>();
        public object Result1()
        {
            for (int x = 0; x <= 999; x++)
            {
                for (int y = 0; y <= 999; y++)
                {
                    coordinates.Add(new Light(x, y));
                }
            }

            //foreach (var instruction in System.IO.File.ReadAllLines("DayInputs/day6.txt"))
            //{
            //    if (instruction.StartsWith("turn on") || instruction.StartsWith("turn off"))
            //    {
            //        var split = instruction.Split(' ');
            //        var xRange = split[2].Split(',').Select(Int32.Parse).ToArray();
            //        var yRange = split[4].Split(',').Select(Int32.Parse).ToArray();
            //        var range = coordinates.Where(x => x.X >= xRange[0] && x.X <= yRange[0] && x.Y >= xRange[1] && x.Y <= yRange[1]);
            //        foreach (var item in range)
            //        {
            //            item.On = instruction.StartsWith("turn on");
            //        }
            //    }
            //    else
            //    {
            //        var split = instruction.Split(' ');
            //        var xRange = split[1].Split(',').Select(Int32.Parse).ToArray();
            //        var yRange = split[3].Split(',').Select(Int32.Parse).ToArray();
            //        var range = coordinates.Where(x => x.X >= xRange[0] && x.X <= yRange[0] && x.Y >= xRange[1] && x.Y <= yRange[1]);
            //        foreach (var item in range)
            //        {
            //            item.On = !item.On;
            //        }
            //    }
            //}
            return coordinates.Count(x => x.On);
        }

        public object Result2()
        {
            foreach (var instruction in System.IO.File.ReadAllLines("DayInputs/day6.txt"))
            {
                if (instruction.StartsWith("turn on") || instruction.StartsWith("turn off"))
                {
                    var on = instruction.StartsWith("turn on");
                    var split = instruction.Split(' ');
                    var xRange = split[2].Split(',').Select(Int32.Parse).ToArray();
                    var yRange = split[4].Split(',').Select(Int32.Parse).ToArray();
                    var range = coordinates.Where(x => x.X >= xRange[0] && x.X <= yRange[0] && x.Y >= xRange[1] && x.Y <= yRange[1]);
                    foreach (var item in range)
                    {
                        if (on)
                            item.Brightness += 1;
                        else
                        {
                            if (item.Brightness > 0)
                                item.Brightness -= 1;
                        }

                    }
                }
                else
                {
                    var split = instruction.Split(' ');
                    var xRange = split[1].Split(',').Select(Int32.Parse).ToArray();
                    var yRange = split[3].Split(',').Select(Int32.Parse).ToArray();
                    var range = coordinates.Where(x => x.X >= xRange[0] && x.X <= yRange[0] && x.Y >= xRange[1] && x.Y <= yRange[1]);
                    foreach (var item in range)
                    {
                        item.Brightness += 2;
                    }
                }
            }
            return coordinates.Sum(x => x.Brightness);
        }

        public class Light
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool On { get; set; }
            public int Brightness { get; set; }
            public Light(int x, int y)
            {
                X = x; Y = y;
            }
        }
    }
}

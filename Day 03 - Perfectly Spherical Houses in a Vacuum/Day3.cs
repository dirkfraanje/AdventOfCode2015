using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day3
    {
        readonly static string input = System.IO.File.ReadAllText("DayInputs/day3.txt");
        public static object Result1()
        {
            HashSet<Coordinate> houses = new HashSet<Coordinate>();
            int x = 0;
            int y = 0;
            houses.Add(new Coordinate(x, y));
            foreach (var move in input)
            {
                switch (move)
                {
                    case '>':
                        x++;
                        break;
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '<':
                        x--;
                        break;
                    default:
                        break;
                }
                houses.Add(new Coordinate(x, y));
            }
            return houses.Count();
        }

        public static object Result2()
        {
            HashSet<Coordinate> houses = new HashSet<Coordinate>();
            int santaX = 0;
            int santaY = 0;
            int roboSantaX = 0;
            int roboSantaY = 0;
            houses.Add(new Coordinate(0, 0));
            bool santa = true;
            foreach (var move in input)
            {
                if (santa)
                {
                    switch (move)
                    {
                        case '>':
                            santaX++;
                            break;
                        case '^':
                            santaY++;
                            break;
                        case 'v':
                            santaY--;
                            break;
                        case '<':
                            santaX--;
                            break;
                        default:
                            break;
                    }
                    houses.Add(new Coordinate(santaX, santaY));
                    santa = false;
                }
                else
                {
                    switch (move)
                    {
                        case '>':
                            roboSantaX++;
                            break;
                        case '^':
                            roboSantaY++;
                            break;
                        case 'v':
                            roboSantaY--;
                            break;
                        case '<':
                            roboSantaX--;
                            break;
                        default:
                            break;
                    }
                    houses.Add(new Coordinate(roboSantaX, roboSantaY));
                    santa = true;
                }

            }
            return houses.Count();

        }

        private record struct Coordinate(int x, int y)
        {
            int X = x;
            int Y = y;
        }
    }
}

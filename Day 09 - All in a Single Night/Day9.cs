using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day9
    {
        static List<Location> locations = new List<Location>();
        static List<RouteDistance> routes = new List<RouteDistance>();
        static List<RouteDistance> shortesCombinations = new List<RouteDistance>();
        public static object Result1()
        {
            ParseInput();
            var totalDistance = 0;
            var orderRoutes = routes.OrderBy(x => x.Distance).ToList();
            foreach (var location in locations)
            {
                shortesCombinations.AddRange(orderRoutes.Where(x => x.Location1 == location || x.Location2 == location).Take(2));
            }

            var start = shortesCombinations[shortesCombinations.Count - 2];
            var startLocation2 = shortesCombinations[shortesCombinations.Count - 1];
            var locationToStartWith = startLocation2.Location1 == start.Location1 || startLocation2.Location2 == start.Location1 ? start.Location1 : start.Location2;
            var nextLocation = start.Location1 == locationToStartWith ? start.Location2 : start.Location1;

            totalDistance += start.Distance;
            for (int i = 0; i < locations.Count - 2; i++)
            {
                var nextCombinations = shortesCombinations.Where(x => x.Location1 == nextLocation || x.Location2 == nextLocation).OrderBy(r => r.Distance).ToArray();
                var next = nextCombinations.First();
                //Console.WriteLine($"{next.Location1.Name} to {next.Location2.Name} = {next.Distance}");
                totalDistance += next.Distance;
                nextLocation = next.Location1 == nextLocation ? next.Location2 : next.Location1;
                foreach (var item in nextCombinations.ToArray())
                {
                    shortesCombinations.Remove(item);
                }
            }

            return totalDistance;
        }

        public static object Result2()
        {
            var totalDistance = 0;
            var orderRoutes = routes.OrderByDescending(x => x.Distance).ToList();
            var locationsUsed = new List<Location>();
            //To start use the top 2
            totalDistance += orderRoutes[0].Distance;
            totalDistance += orderRoutes[1].Distance;
            locationsUsed.Add(orderRoutes[0].Location1);
            locationsUsed.Add(orderRoutes[0].Location2);
            locationsUsed.Add(orderRoutes[1].Location1);
            locationsUsed.Add(orderRoutes[1].Location2);
            orderRoutes.Remove(orderRoutes[0]);
            orderRoutes.Remove(orderRoutes[0]);
            while (locationsUsed.Count < 17)
            {
                if (locationsUsed.Count(x => x == orderRoutes[0].Location1) == 2 || locationsUsed.Count(x => x == orderRoutes[0].Location2) == 2)
                {
                    orderRoutes.Remove(orderRoutes[0]);
                    continue;
                }
                totalDistance += orderRoutes[0].Distance;
                locationsUsed.Add(orderRoutes[0].Location1);
                locationsUsed.Add(orderRoutes[0].Location2);
                orderRoutes.Remove(orderRoutes[0]);
                if (ListContainsOtherList<Location>.ContainsAll(locations, locationsUsed))
                    break;
            }
            return totalDistance;
        }

        static void ParseInput()
        {
            foreach (var distance in System.IO.File.ReadAllLines("DayInputs/day9.txt"))
            {
                var distanceSplit = distance.Split(' ');
                if (!locations.Any(x => x.Name == distanceSplit[0]))
                    locations.Add(new Location(distanceSplit[0]));
                if (!locations.Any(x => x.Name == distanceSplit[2]))
                    locations.Add(new Location(distanceSplit[2]));
                routes.Add(new RouteDistance(locations.First(x => x.Name == distanceSplit[0]), locations.First(x => x.Name == distanceSplit[2]), int.Parse(distanceSplit[4])));
            }
        }
    }

    internal class Location
    {
        public string Name { get; set; }
        public Location(string name)
        {
            Name = name.Trim();
        }
    }

    class ListContainsOtherList<T>
    {
        public static bool ContainsAll(List<T> first, List<T> second)
        {
            return !first.Except(second).Any();
        }
    }
}

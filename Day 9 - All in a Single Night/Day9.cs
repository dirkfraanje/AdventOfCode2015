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
            var locationSequence = new List<Location>();
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
                Console.WriteLine($"{next.Location1.Name} to {next.Location2.Name} = {next.Distance}");
                totalDistance += next.Distance;
                nextLocation = next.Location1 == nextLocation ? next.Location2 : next.Location1;
                foreach (var item in nextCombinations.ToArray())
                {
                    shortesCombinations.Remove(item);
                }
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class RouteDistance
    {
        public Location Location1 { get; set; }
        public Location Location2 { get; set; } 
        public int Distance { get; set; }
        public RouteDistance(Location location1, Location location2, int distance)
        {
            Location1 = location1;
            Location2 = location2;
            Distance = distance;
        }
    }
}

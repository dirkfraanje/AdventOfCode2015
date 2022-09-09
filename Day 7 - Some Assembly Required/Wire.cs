using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Wire
    {
        public string Identifier { get; set; }
        public int Signal { get; set; }
        public bool HasBeenSet { get; set; }
    }
}

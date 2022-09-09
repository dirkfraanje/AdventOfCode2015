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
        private int signal;
        public int Signal
        {
            get => signal; set
            {
                signal = value;
                HasBeenSet = true;
            }
        }
        public bool HasBeenSet { get; private set; }
    }
}

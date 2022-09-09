using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Instruction
    {
        public Wire TargetWire { get; init; }
        public InstructionType InstructionType { get; init; }
        public object LeftValue { get; set; }
        public object RightValue { get; set; }
        List<Wire> wires;
        public Instruction(List<Wire> wires, string[] splittedInstruction)
        {
            this.wires = wires;
            TargetWire = wires.First(x => x.Identifier == splittedInstruction.Last());
            var instruction = splittedInstruction[0].Split(' ');
            switch (instruction.Count())
            {
                case 1:
                    InstructionType = InstructionType.SET;
                    LeftValue = SetValue(instruction[0]);
                    break;
                case 2:
                    LeftValue = SetValue(instruction[1]);
                    InstructionType = (InstructionType)Enum.Parse(typeof(InstructionType), instruction[0]);
                    break;
                case 3:
                    LeftValue = SetValue(instruction[0]);
                    RightValue = SetValue(instruction[2]);
                    InstructionType = (InstructionType)Enum.Parse(typeof(InstructionType), instruction[1]);
                    break;
                default:
                    throw new ArgumentException("No action defined for instruction with count of " + instruction.Count());
            }
        }

        internal void Execute()
        {
            switch (InstructionType)
            {
                case InstructionType.NOT:
                    TargetWire.Signal = 65535 - (int)LeftValue;
                    break;
                case InstructionType.RSHIFT:
                    TargetWire.Signal = (int)LeftValue >> (int)RightValue;
                    break;
                case InstructionType.LSHIFT:
                    TargetWire.Signal = (int)LeftValue << (int)RightValue;
                    break;
                case InstructionType.AND:
                    TargetWire.Signal = (int)LeftValue & (int)RightValue;
                    break;
                case InstructionType.OR:
                    TargetWire.Signal = (int)LeftValue | (int)RightValue;
                    break;
                case InstructionType.SET:
                    TargetWire.Signal = (int)LeftValue;
                    break;
                default:
                    break;
            }
        }

        private object SetValue(string value)
        {
            if (Int32.TryParse(value, out var val))
                return val;
            else
            {
                var wire = wires.FirstOrDefault(x=>x.Identifier == value);
                if (wire != null)
                    return wire;
                else
                {
                    var newWire = new Wire() { Identifier = value };
                    wires.Add(newWire);
                    return newWire;
                }
            }
                
        }
    }
}

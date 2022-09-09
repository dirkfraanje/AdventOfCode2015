using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day7
    {
        static List<Wire> wires = new List<Wire>();
        static List<Instruction> instructions = new List<Instruction>();
        public static object Result1()
        {
            ParseInput();
            while (true)
            {
                var wiresReady = wires.Where(x=>x.HasBeenSet).ToArray();
                foreach (var wire in wiresReady)
                {
                    var wiresWitLeftValuesUsingWire = instructions.Where(x => x.LeftValue == wire);
                    foreach (var wireLeft in wiresWitLeftValuesUsingWire)
                    {
                        wireLeft.LeftValue = wire.Signal;
                    }
                    var wiresWitRightValuesUsingWire = instructions.Where(x => x.RightValue == wire);
                    foreach (var rightValue in wiresWitRightValuesUsingWire)
                    {
                        rightValue.RightValue = wire.Signal;
                    }
                }

                var inputReadyInstructions = instructions.Where(x => int.TryParse($"{x.LeftValue}", out int result) && (x.RightValue == null || int.TryParse($"{x.RightValue}", out int result2)));
                if (!inputReadyInstructions.Any())
                    return wires.First(x=>x.Identifier == "a").Signal;
                foreach (var instruction in inputReadyInstructions.ToArray())
                {
                    instruction.Execute();
                    instructions.Remove(instruction);
                }
               
            }
            return null;
        }

        private static void ParseInput()
        {
            foreach (var item in System.IO.File.ReadAllLines("DayInputs/day7.txt"))
            {
                var splittedInstruction = item.Split("->",StringSplitOptions.TrimEntries);
                wires.Add(new Wire() { Identifier = splittedInstruction.Last() });
                instructions.Add(new Instruction(wires, splittedInstruction));
            }
        }
    }
}

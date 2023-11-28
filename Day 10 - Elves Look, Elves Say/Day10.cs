using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2015
{
    internal class Day10
    {
        public static object Result1()
        {
            var number = $"{1113122113}";
            //Console.WriteLine(number.Length);
            for (int i = 0; i < 15; i++)
            {
                var sum = 0;
                foreach (var item in number)
                {
                    sum += int.Parse($"{item}");
                }
                Console.WriteLine(sum);
                number = CalculateNext($"{number}");
                //Console.WriteLine(number);
              
            }
            return number.Length;
        }

        private static string CalculateNext(string number)
        {
            var lastNumber = "";
            var currentCounter = 1;
            var newNumber = "";
            for (int i = 0; i < number.Length; i++)
            {
                if ($"{number[i]}" == lastNumber)
                   currentCounter++;
                if (i+1 == number.Length)
                {
                    newNumber = $"{newNumber}{currentCounter}{number[i]}";
                    return newNumber;
                }
                if ($"{number[i]}" != $"{number[i + 1]}")
                {
                    newNumber = $"{newNumber}{currentCounter}{number[i]}";
                    currentCounter = 1;
                }
                lastNumber = $"{number[i]}";
            }
            return newNumber;
        }
    }
}

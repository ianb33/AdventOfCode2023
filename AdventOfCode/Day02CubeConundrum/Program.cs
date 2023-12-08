using System.Runtime.ConstrainedExecution;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Day02CubeConundrum
{
    internal class Program
    {
        const int redCubes = 12;
        const int greenCubes = 13;
        const int blueCubes = 14;
        static void Main(string[] args)
        {
            var inputs = File.ReadLines("C:/Users/ianbe/Documents/Github/AdventOfCode2023/AdventOfCode/Day02CubeConundrum/input.txt").Select(x => x.Split(';')).ToArray();
            var total = 0;

            foreach (string[] input in inputs)
            {
                if(IsValid(input)) 
                {
                    total += Array.IndexOf(inputs, input) + 1;
                }
            }
            Console.WriteLine(total);
        }

        

        public static bool IsValid(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("red"))
                {
                    string value = Regex.Match(input[i], @"\b\d+(?=\s*red)").Value;
                    if (int.Parse(value) > redCubes)
                    {
                        return false;
                    }
                }
                if (input[i].Contains("green"))
                {
                    string value = Regex.Match(input[i], @"\b\d+(?=\s*green)").Value;
                    if (int.Parse(value) > greenCubes)
                    {
                        return false;
                    }
                }
                if (input[i].Contains("blue"))
                {
                    string value = Regex.Match(input[i], @"\b\d+(?=\s*blue)").Value;
                    if (int.Parse(value) > blueCubes)
                    {
                        return false;
                    }
                }
                Console.WriteLine(input[i]);
            }
            return true;
        }
    }
}
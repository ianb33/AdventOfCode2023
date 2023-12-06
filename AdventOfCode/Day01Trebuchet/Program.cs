using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Day01Trebuchet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputs = /*new string[] { "5onesixsevenphxtmlqhzfcjxrknpv" };*/ File.ReadLines("C:/Users/ianbe/Documents/Github/AdventOfCode2023/AdventOfCode/Day01Trebuchet/input.txt").ToArray();
            long total = 0;
            List<string> numSpelled = new() { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //string test = "abalds, kfjasdlkfjads, lkfjasdf";
            //var mysplits = test.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            // Part 2

            foreach (string input in inputs)
            {
                List<int> output = new List<int>();

                var splitInput = SplitAlpha(input);

                foreach (string s in splitInput)
                {
                    // Define a regular expression pattern to match numbers
                    string pattern = @"(\d+)";

                    // Use Regex.Match to find the first occurrence of a number in the string
                    Match match = Regex.Match(s, pattern);
                    for (int i = 0; i < s.Length; i++)
                    {
                        // Check if a match was found and if it can be converted to an int
                        if (match.Success && int.TryParse(match.Value, out int result))
                        {
                            s.ToString();
                            int[] digitsArray = s.Select(c => int.Parse(c.ToString())).ToArray();

                            foreach (int j in digitsArray)
                            {
                                output.Add(j);
                            }
                        }
                        else
                        {
                            for (int k = 0; k < numSpelled.Count; k++)
                            {
                                var part = new string(s.Skip(i).Take(numSpelled[k].Length).ToArray());
                                if (part == numSpelled[k])
                                {
                                    output.Add(numSpelled.IndexOf(part));
                                }

                            }
                        }
                    }
                }
                if (output.First() > 0 && output.Last() >= 0)
                {
                    try
                    {
                        total += long.Parse($"{output.First()}{output.Last()}");
                    }
                    catch (OverflowException e)
                    {
                        Console.Write(output.First().ToString());
                        Console.Write(output.Last().ToString());
                    }
                }
                Console.WriteLine($"{output.First()}{output.Last()}     {input}");
            }
            Console.WriteLine($"Part 1: {total}");
        }

        public static IEnumerable<string> SplitAlpha(string input)
        {
            var words = new List<string> { string.Empty };
            for (var i = 0; i < input.Length; i++)
            {
                words[words.Count - 1] += input[i];
                if (i + 1 < input.Length && char.IsLetter(input[i]) != char.IsLetter(input[i + 1]))
                {
                    words.Add(string.Empty);
                }
            }
            return words;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var file = File.ReadAllLines("input.txt");
        var commands = new int[4];
        foreach (var s in file[0].Split())
        {
            switch (s)
            {
                case "-c":
                    commands[0] += 1; 
                    break;
                case "-d":
                    commands[1] += 1; 
                    break;
                case "-i":
                    commands[2] += 1; 
                    break;
                case "-u":
                    commands[3] += 1; 
                    break;
            }
        }

        var uniqueStrings = new List<UniqueString>();
        var i = 1;
        var d = 0;
        while (i < file.Length - 1)
        {
            var count = 1;
            var j = 1;
            uniqueStrings.Add(new UniqueString(count, file[i]));
            if (commands[2] == 1)
            {
                while (j+i<file.Length && string.Equals(file[i], file[j+i], StringComparison.CurrentCultureIgnoreCase))
                {
                    count++;
                    j++;
                }
            }
            else
            {
                while (j+i<file.Length && file[i] == file[j + i])
                {
                    count++;
                    j++;
                }
            }
            uniqueStrings[d].Count = count;
            d++;
            
            if (count == 1)
            {
                i++;
            }
            else
            {
                i += j;
            }
        }
        
        var outputFile = new List<string>();
        if (!(commands[1] == 1 & commands[3] == 1))
        {
            if (commands[1] == 1)
            {
                uniqueStrings = uniqueStrings.Where(s => s.Count > 1).ToList();
            }

            if (commands[3] == 1)
            {
                uniqueStrings = uniqueStrings.Where(s => s.Count == 1).ToList();
            }

            outputFile = commands[0] == 1 ? uniqueStrings.Select(s => $"{s.Count} {s.Str}").ToList() : uniqueStrings.Select(s => s.Str).ToList();
        }
        File.WriteAllLines("output.txt", outputFile);
    }
}

internal class UniqueString
{
    public UniqueString(int count, string str)
    {
        Count = count;
        Str = str;
    }

    public int Count { get; set; }
    public string Str { get; set; }
}
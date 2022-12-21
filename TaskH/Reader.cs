using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

internal static class Reader
{
    public static string[] ReadFile(string fileName)
    {
        var str = File.ReadAllLines(fileName)[0] + " ";
        var sb = new StringBuilder();
        var i = 0;
        while (i < str.Length - 1)
        {
            if (str[i] != str[i+1])
            {
                sb.Append(str[i]);
            }

            i++;
        }

        return sb.ToString().Split();

    }
}
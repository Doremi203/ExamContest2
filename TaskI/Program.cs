using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        var file = File.ReadAllLines("input.txt");
        var mas = new int[file.Length][];
        for (int i = 0; i < file.Length; i++)
        {
            mas[i] = Array.ConvertAll(file[i].Split(), Convert.ToInt32);
        }

        var checkLines = true;
        var checkColoms = true;
        var checkSquare = true;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                for (int k = j+1; k < 9; k++)
                {
                    if (mas[i][j] == mas[i][k])
                    {
                        checkLines = false;
                        break;
                    }
                }
                for (int k = i+1; k < 9; k++)
                {
                    if (mas[k][j] == mas[i][j])
                    {
                        checkColoms = false;
                        break;
                    }
                }
                
            }
        }
        /*Dictionary<int, int[]> numLines = new Dictionary<int, int[]>();
        Dictionary<int, int[]> numColoms = new Dictionary<int, int[]>();

        for (int i = 0; i < 9; i++)
        {
            numLines.Add(i,new int[9]);
            numColoms.Add(i,new int[9]);
        }
        
        for (int i = 0; i < mas.Length; i++)
        {
            var nums = new int[9];
            
            for (int j = 0; j < mas[0].Length; j++)
            {
                if (nums[mas[i][j] - 1] > 0)
                {
                    checkLines = false;
                    break;
                }

                if (numColoms[j][mas[i][j] - 1] > 0)
                {
                    checkColoms = false;
                    break;
                }

                numColoms[j][mas[i][j] - 1] += 1;
                nums[mas[i][j] - 1] += 1;
            }
            
            numLines[i] = nums;
        }
*/
        for (int i = 0; i < 9; i+=3)
        {
            for (int j = 0; j < 9; j+=3)
            {
                var nums = new int[9];
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        if (nums[mas[k][l] - 1] > 0)
                        {
                            checkSquare = false;
                            break;
                        }

                        nums[mas[k][l] - 1] += 1;
                    }
                }
            }
        }




        if (checkLines && checkColoms && checkSquare)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
        
        watch.Stop();

        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }
}
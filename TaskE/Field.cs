using System;
using System.Text;

public class Field
{
    public int[,] Matrix { get; }

    public Field(int[,] matrix)
    {
        Matrix = matrix;
    }

    public void FillIn(string fillType)
    {
        switch (fillType)
        {
            case "top to bottom":
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        Matrix[i, j] = i + j + 1;
                    }
                }
                break;
            case "bottom to top":
                var k = 0;
                for (int i = Matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        Matrix[i, j] = k + j + 1;
                    }
                    k++;
                }
                break;
            default:
                throw new ArgumentException("Incorrect input");
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (j != Matrix.GetLength(1)-1)
                {
                    sb.Append(Matrix[i, j] + " ");
                }
                else
                {
                    sb.Append(Matrix[i, j]);
                }
            }
            if (i != Matrix.GetLength(0) - 1)
            {
                sb.Append("\n"); 
            }
        }

        return sb.ToString();
    }
}
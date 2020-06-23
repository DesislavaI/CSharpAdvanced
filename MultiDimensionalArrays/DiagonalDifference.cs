//Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).
//Input
//On the first line, you are given the integer N – the size of the square matrix
//The next N lines holds the values for every row – N numbers separated by a space
//Output
//Print the absolute difference between the sums of the primary and the secondary diagonal

using System;
using System.Linq;

namespace DiagonalDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());

			int[,] matrix = new int[size, size];

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				int[]colElements = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = colElements[col];
				}
			}

			int primaryDiagonal = 0;
			int secondaryDiagonal = 0;

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (i == j)
					{
						primaryDiagonal += matrix[i, j];
					}

					if (j == size - i - 1)
					{
						secondaryDiagonal += matrix[i, j];
					}
				}
			}

			Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));

		}
	}
}

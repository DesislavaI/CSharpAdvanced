//Find the count of 2 x 2 squares of equal chars in a matrix.
//Input
//On the first line, you are given the integers rows and cols – the matrix’s dimensions
//Matrix characters come at the next rows lines (space separated)
//Output
//Print the number of all the squares matrixes you have found

using System;
using System.Linq;

namespace _2x2SquaresinMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] matrixSize = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
			string[,] matrix = new string[matrixSize[0], matrixSize[1]];

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				string[] colElements = Console.ReadLine()
					.Split();
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = colElements[col];
				}
			}

			int count = 0;

			for (int row = 0; row < matrix.GetLength(0) - 1; row++)
			{
				for (int col = 0; col < matrix.GetLength(1) - 1; col++)
				{
					if (matrix[row, col] == matrix[row, col + 1]
					&& matrix[row, col] == matrix[row + 1, col]
					&& matrix[row, col] == matrix[row + 1, col + 1])
					{
						count++;
					}
				}
			}

			Console.WriteLine(count);
		}
	}
}


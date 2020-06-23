//You are given an empty text.Your task is to implement 4 commands related to manipulating the text
//1 someString - appends someString to the end of the text
//2 count - erases the last count elements from the text
//3 index - returns the element at position index from the text
//4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
//Input
//The first line contains n, the number of operations.
//Each of the following n lines contains the name of the operation followed by the command argument, if any, separated by space in the following format CommandName Argument.
//Output
//For each operation of type 3 print a single line with the returned character of that operation.
//Constraints
//1 ≤ N ≤ 105
//The length of the text will not exceed 1000000
//All input characters are English letters.
//It is guaranteed that the sequence of input operation is possible to perform.

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			Stack<string> stackOfText = new Stack<string>();

			string text = "";

			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				string []input = Console.ReadLine()
					.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				if (input[0] == "1")
				{
					stackOfText.Push(text);
					text += input[1];
				}
				else if (input[0] == "2")
				{
					int index = int.Parse(input[1]);
					stackOfText.Push(text);
					text = text.Substring(0, text.Length - index);
				}
				else if (input[0] == "3")
				{
					int index = int.Parse(input[1]);
					Console.WriteLine(text[index -1]);
				}
				else if (input[0] == "4")
				{
					text = stackOfText.Pop();
				}
			}			
		}
	}
}

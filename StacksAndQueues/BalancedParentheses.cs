//Given a sequence consisting of parentheses, determine whether the expression is balanced.A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a closed parenthesis that occurs after the former.Also, the interval between them must be balanced.You will be given three types of parentheses: (, {, and[.
//{[()]}
//    -This is a balanced parenthesis.
//{[(])}
//    -This is not a balanced parenthesis.
//Input
//Each input consists of a single line, the sequence of parentheses.
//Output
//For each test case, print on a new line "YES" if the parentheses are balanced.
//Otherwise, print "NO".Do not print the quotes.
//Constraints
//1 ≤ lens ≤ 1000, where lens is the length of the sequence.
//Each character of the sequence will be one of {, }, (, ), [,].


using System;
using System.Collections.Generic;

class MainClass
{
    public static void Main()
    {
        char[] parentheses = Console.ReadLine().ToCharArray();
        Dictionary<char, char> closingBrackets = new Dictionary<char, char>() { { ']', '[' }, { ')', '(' }, { '}', '{' } };
        Stack<char> stack = new Stack<char>();
        foreach (char bracket in parentheses)
        {
            if (stack.Count > 0 && closingBrackets.ContainsKey(bracket) && stack.Peek() == closingBrackets[bracket])
            {
                stack.Pop();
            }
            else
            {
                stack.Push(bracket);
            }
        }
        if (stack.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}

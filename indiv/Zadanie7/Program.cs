using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie7
{
    class Program
    {
        static void Main(string[] args)
        {
            string postfix = "32 2 + 5 *";

            string prefix = ConvertPostfixToInfix(postfix);

            Console.WriteLine("Префикс: " + prefix);
        }

        static string ConvertPostfixToInfix(string postfix)
        {
            Stack<string> stack = new Stack<string>();

            string[] tokens = postfix.Split(' ');

            foreach (string token in tokens)
            {
                if (IsOperator(token))
                {
                    string operand2 = stack.Pop();
                    string operand1 = stack.Pop();
                    string newExp = "(" + operand1 + token + operand2 + ")";
                    stack.Push(newExp);
                }
                else
                {
                    stack.Push(token);
                }
            }

            return stack.Peek();
        }

        static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "/" || token == "*";
        }
    }
}

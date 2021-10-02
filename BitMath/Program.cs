using System;

namespace BitMath
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = GetCommand();

            while (command.ToUpperInvariant() != "X")
            {
                Console.Write("Введите число a: ");
                string a = Console.ReadLine();
                UnlimitedInteger uiA = UnlimitedInteger.Parse(a);

                Console.Write("Введите число b: ");
                string b = Console.ReadLine();
                UnlimitedInteger uiB = UnlimitedInteger.Parse(b);

                PrintBreak();

                UnlimitedInteger result = UnlimitedInteger.Zero();

                switch(command)
                {
                    case "+":
                        { result = uiA + uiB; }
                        break;
                    case "-":
                        { result = uiA - uiB; }
                        break;
                    case "*":
                        { result = uiA * uiB; }
                        break;
                    case "/":
                        { result = uiA / uiB; }
                        break;
                    case "%":
                        { result = uiA % uiB; }
                        break;
                }

                Console.WriteLine("Ответ: " + result.ToString(10));


                command = GetCommand();
            }
        }

        private static string GetCommand()
        {
            PrintBreak();
            Console.WriteLine("Решение целочисленной операции a?b=: ");
            Console.Write("Введите оператор (+, - , *, /, %. X - выход): ");
            string command = Console.ReadLine();
            return command;
        }

        private static void PrintBreak()
        {
            Console.WriteLine("_____________________________________");
        }
    }
}

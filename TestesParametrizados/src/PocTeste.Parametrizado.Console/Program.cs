using System;
using static System.Console;

namespace PocTeste.Parametrizado.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(Calculator.Add(1, 5));
        }
    }

    public static class Calculator
    {
        public static int Add(int value1, int value2)
        {
            if (value1 > value2)
                return 0;
            return value1 + value2;
        }
    }
}

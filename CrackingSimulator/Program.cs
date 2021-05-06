using CrackingSimulator.App;
using CrackingSimulator.Util;
using System;

namespace CrackingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new Simulator();
            Printer.PrintWellcomeMessage();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
            simulator.Start();
            Printer.PrintEndMessage();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}

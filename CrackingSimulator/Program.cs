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
            simulator.WaitKeyPress();
        }
    }
}

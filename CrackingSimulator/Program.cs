using CrackingSimulator.App;
using System;

namespace CrackingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new Simulator();
            Console.WriteLine("Hello World!");
            simulator.WaitKeyPress();
        }
    }
}

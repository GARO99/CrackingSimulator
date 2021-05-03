using CrackingSimulator.Util;
using System;
using System.Threading;

namespace CrackingSimulator.App
{
    public class Simulator
    {
        private Printer printer { get; set; }

        public Simulator()
        {
            printer = new Printer();
        }

        private void Wait() 
        {
            while (true)
            {
                Console.ReadKey(true);
                if (!Console.KeyAvailable)
                    break;
            }
        }

        /// <summary>
        /// Wait for 5 keypresses and type on the console
        /// </summary>
        public void WaitKeyPress()
        {
            int position = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    WriteFakeComand(position, out int commandArrayPosition);
                    Wait();
                    position = commandArrayPosition;
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Type on the console a piece of a fake command
        /// </summary>
        /// <param name="commandArrayPosition"> position in the array that have the fake commands </param>
        private void WriteFakeComand(int commandArrayCurrentPosition, out int commandArrayPosition)
        {
            char[] cammandArray = Printer.commandText.ToCharArray();
            commandArrayPosition = commandArrayCurrentPosition;
            for (int i = 0; i < 5; i++)
            {
                if (commandArrayCurrentPosition < cammandArray.Length)
                {
                    Console.Write(cammandArray[commandArrayCurrentPosition]);
                    printer.PrintMessage(commandArrayCurrentPosition, out bool wait);
                    commandArrayCurrentPosition++;
                    commandArrayPosition = commandArrayCurrentPosition;
                    Thread.Sleep(100);
                    if (wait) break;
                }
            }
        }
    }
}

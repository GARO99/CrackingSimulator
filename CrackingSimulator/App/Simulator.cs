using CrackingSimulator.Util;
using System;
using System.Threading;

namespace CrackingSimulator.App
{
    public class Simulator
    {
        private Printer Printer { get; set; }

        public Simulator()
        {
            Printer = new Printer();
        }

        /// <summary> Start the simulation </summary>
        public void Start()
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

        /// <summary> Type on the console a piece of a fake command </summary>
        /// <param name="commandArrayCurrentPosition">The cuerrent position in the array that have the fake commands to start the print</param>
        /// <param name="commandArrayPosition">out parameter with the position where it stayed the array that have the fake commands</param>        
        private void WriteFakeComand(int commandArrayCurrentPosition, out int commandArrayPosition)
        {
            char[] cammandArray = Printer.CommandText.ToCharArray();
            commandArrayPosition = commandArrayCurrentPosition;
            for (int i = 0; i < 5; i++)
            {
                if (commandArrayCurrentPosition < cammandArray.Length)
                {
                    Console.Write(cammandArray[commandArrayCurrentPosition]);
                    Printer.PrintEvent(commandArrayCurrentPosition, out bool eventIsPrinted);
                    commandArrayCurrentPosition++;
                    commandArrayPosition = commandArrayCurrentPosition;
                    Thread.Sleep(100);
                    if (eventIsPrinted) break;
                }
            }
        }

        /// <summary> Wait for the extra console input to be read </summary>
        private void Wait()
        {
            while (true)
            {
                Console.ReadKey(true);
                if (!Console.KeyAvailable)
                    break;
            }
        }
    }
}

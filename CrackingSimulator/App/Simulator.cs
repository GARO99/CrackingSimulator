using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CrackingSimulator.App
{
    public class Simulator
    {
        /// <summary>
        /// Wait for 5 keypresses and type on the console
        /// </summary>
        public void WaitKeyPress()
        {
            int contKeys = 0;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    contKeys++;
                    if (contKeys == 5)
                    {
                        WriteFakeComand(out int commandArrayPosition);
                        contKeys = 0;
                    }
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Type on the console a piece of a fake command
        /// </summary>
        /// <param name="commandArrayPosition"> position in the array that have the fake commands </param>
        private void WriteFakeComand(out int commandArrayPosition)
        {
            throw new NotImplementedException();
        }
    }
}

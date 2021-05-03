using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CrackingSimulator.Util
{
    public class Printer
    {
        public static string commandText { get; set; }

        public Printer()
        {
            commandText = $"init connection @Server 284.753.123.741{Environment.NewLine}" +
                          $"access folder [Accounts]{Environment.NewLine}" +
                          $"override security settings{Environment.NewLine}" +
                          $"list admin users >>{Environment.NewLine}" +
                          $"launch authCrack.bin{Environment.NewLine}" +
                          $"activate crack{Environment.NewLine}" +
                          $"access user [BankAdmin] at [284.753.123.741]{Environment.NewLine}";
        }

        public void PrintMessage(int position, out bool wait)
        {
            wait = false;
            switch (position)
            {
                case 62:
                    WaitSequence();
                    PrintAccessDenied();
                    wait = true;
                    break;
                default:
                    break;
            }
        }

        public void WaitSequence()
        {
            for (int i = 0; i < 30; i++)
            {
                if (i == 49) 
                    Console.Write($"*{Environment.NewLine}");
                else
                    Console.Write("*");
                Thread.Sleep(300);
            }
            while (true)
            {
                Console.ReadKey(true);
                if (!Console.KeyAvailable)
                    break;
            }
        }

        private void PrintAccessDenied()
        {
            Console.WriteLine($"====================={Environment.NewLine}" +
                              $"|   ACCESS DENIED   |{Environment.NewLine}" +
                              $"=====================");
        }
    }
}

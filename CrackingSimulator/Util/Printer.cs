using System;
using System.Linq;
using System.Threading;

namespace CrackingSimulator.Util
{
    public class Printer
    {
        public static string CommandText { get; set; }

        public Printer()
        {
            CommandText = $"init connection @Server 284.753.123.741{Environment.NewLine}" +
                          $"access folder [Accounts]{Environment.NewLine}" +
                          $"override security settings{Environment.NewLine}" +
                          $"list admin users >>{Environment.NewLine}" +
                          $"launch authCrack.bin{Environment.NewLine}" +
                          $"activate crack{Environment.NewLine}" +
                          $"access user [BankAdmin] at [284.753.123.741]{Environment.NewLine}" +
                          $"run password crack{Environment.NewLine}" +
                          $"init login{Environment.NewLine}" +
                          $"user: BankAdmin{Environment.NewLine}" +
                          $"password: ************{Environment.NewLine}" +
                          $"use dbBank{Environment.NewLine}" +
                          $"SELECT CUSTOMERS FROM BANKACCOUNTS WHERE BALANCE > 1000000.00{Environment.NewLine}" +
                          $"transfer all [BALANCE] to MyAccount{Environment.NewLine}" +
                          $"positive{Environment.NewLine}" +
                           "CODE[try {" + Environment.NewLine +
                          $"    Statement authRequest = conn.crStat();{Environment.NewLine}" +
                          $"    ResultSet rs = authRequest.exec(loginQuery);{Environment.NewLine}" +
                          $"    user_id =  rs.getInt(\"GodeModeQ\");" + Environment.NewLine +
                           "    if(hashOf(request.getParam(\"password\") != -1)) {" + Environment.NewLine +
                          $"        throw BadLoginException();{Environment.NewLine}" +
                           "    } else {" + Environment.NewLine +
                          $"        authTransaction(10, minutes);" + Environment.NewLine +
                           "    }" + Environment.NewLine +
                           "}]" + Environment.NewLine +
                          $"transfer all [BALANCE] to MyAccount{Environment.NewLine}" +
                          $"positive{Environment.NewLine}" +
                          $"access [BALANCE] @ MyAccount{Environment.NewLine}" +
                          $"init offshore transfer{Environment.NewLine}" +
                          $"transfer all to ID[654874984651OMNO] @ Cayman Treasury Bank";
        }

        public static void PrintWellcomeMessage()
        {
            string message = "#" + Environment.NewLine +
                             "#" + Environment.NewLine +
                             "#         _______" + Environment.NewLine +
                             "#        /       |" + Environment.NewLine +
                             "#       /    ____|__  __   ____  __   ____ __   __  __ ________   ____  __" + Environment.NewLine +
                             "#      |    /    |  |/  | /    \\|  | /    |  | /  /|__|        | /    \\|  |" + Environment.NewLine +
                             "#      |   |     |   ___|/  __     |/  ___|  |/  /  __|   __   |/  __     |" + Environment.NewLine +
                             "#      |   |     |  |   |  /  \\    |  /   |     /  |  |  |  |  |  /  \\    |" + Environment.NewLine +
                             "#      |    \\____|  |   |  \\__/    |  \\___|     \\  |  |  |  |  |  \\__/    |" + Environment.NewLine +
                             "#       \\        |  |    \\         |\\     |  |\\  \\ |  |  |  |  |\\         |" + Environment.NewLine +
                             "#        \\_______|__|     \\____/|__| \\____|__| \\__\\|__|__|  |__| \\____    |" + Environment.NewLine +
                             "#        /       |                                               |       /" + Environment.NewLine +
                             "#       |   _____|__  ___    ___  __    __ __   ____  __    __   |______/  __  __" + Environment.NewLine +
                             "#       |  |     |__|/   \\__/   \\|  |  |  |  | /    \\|  |__|  |__  /    \\ |  |/  |" + Environment.NewLine +
                             "#       |  |_____ __|            |  |  |  |  |/  __     |__    __|/  __  \\|   ___|" + Environment.NewLine +
                             "#       |____    |  |   _    _   |  |  |  |  |  /  \\    |  |  |  |  /  \\  |  |" + Environment.NewLine +
                             "#        ____|   |  |  | |  | |  |  |__|  |  |  \\__/    |  |  |  |  \\__/  |  |" + Environment.NewLine +
                             "#       |        |  |  | |  | |  |        |  |\\         |  |  |   \\      /|  |" + Environment.NewLine +
                             "#       |_______/|__|__| |__| |__|________|__| \\____/|__|  |__|    \\____/ |__|" + Environment.NewLine +
                             "#" + Environment.NewLine +
                             "#" + Environment.NewLine +
                             "# Press enter to start" + Environment.NewLine +
                             "#";
            Console.WriteLine(message);

        }

        /// <summary> Print a dynamic event according the current position of commands array </summary>
        /// <param name="position"> Current position of commands array </param>
        /// <param name="eventIsPrinted"> out parameter that indicate if a event was printed </param>
        public void PrintEvent(int position, out bool eventIsPrinted)
        {
            eventIsPrinted = false;
            switch (position)
            {
                case 66:
                    WaitSequence();
                    PrintAccessDenied();
                    eventIsPrinted = true;
                    break;
                case 219:
                    WaitSequence();
                    PrintPasswordCrackSimulator();
                    eventIsPrinted = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary> Print a sequence of asterisks imitating load screen </summary>
        public void WaitSequence()
        {
            Console.WriteLine();
            for (int i = 0; i < 25; i++)
            {
                if (i == 24)
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

        /// <summary> Print a message of access denied </summary>
        private void PrintAccessDenied()
        {
            Console.WriteLine($"{Environment.NewLine}" +
                              $"====================={Environment.NewLine}" +
                              $"|   ACCESS DENIED   |{Environment.NewLine}" +
                              $"====================={Environment.NewLine}");
        }

        /// <summary> Print the simulation of a password's crack </summary>
        private void PrintPasswordCrackSimulator() 
        {
            Random random = new Random();
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Console.Write(new string(Enumerable.Repeat(chars, 1).Select(s => s[random.Next(s.Length)]).ToArray()));
                    Thread.Sleep(10);
                }
                if (i < 99)
                {
                    int currentLineCursor = Console.CursorTop;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                }
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}

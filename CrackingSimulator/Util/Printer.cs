using System;
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
                           "}]" +
                          $"transfer all [BALANCE] to MyAccount{Environment.NewLine}" +
                          $"positive{Environment.NewLine}" +
                          $"access [BALANCE] @ MyAccount{Environment.NewLine}" +
                          $"init offshore transfer{Environment.NewLine}" +
                          $"transfer all to ID[654874984651OMNO] @ Cayman Treasury Bank";
        }

        public void PrintMessage(int position, out bool wait)
        {
            wait = false;
            switch (position)
            {
                case 66:
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
                if (i == 29)
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

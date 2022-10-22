using static System.Console;
using System.Collections.Generic;

using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using transactions;
using logProject;


namespace BankAccount
{

    public class Account
    {
        public string? Name;
        public int accountNum;
        public double Balance;
        public List<trans> tr;

        public Account(string? nameo, int accNum, double initBal)
        {
            tr = new List<trans>();
            Name = nameo;
            accountNum = accNum;
            Balance = initBal;
        }
        public void Deposit(double addAmt)
        {
            DateTime now = DateTime.Now;
            try
            {
                Balance += addAmt;
                tr.Add(new trans(addAmt, Balance, now));
                string t = "Log written date: " + now + " *** " + "from method: Deposit() ";
                log obja = new log();
                obja.WriteToLogFile(t);
                WriteLine($"Your balance is {Balance:C} now.");
            }
            catch (Exception ex)
            {
                string text = "Error Log written date: " + now + " *** " + "from method: Deposit() ";
                log obj = new log();
                obj.WriteToErrFile(text);
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
        }
        
        public void Withdraw(double outAmt)
        {
            DateTime now = DateTime.Now;
            try
            {
                if (outAmt <= Balance)
                {
                    Balance -= outAmt;
                }
                else if (outAmt > Balance)
                {
                    WriteLine("Sorry! Your balance is not enough");
                }
                WriteLine($"Your balance is {Balance:C} now.");

                tr.Add(new trans(outAmt * -1, Balance, now));
                string t = "Log written date: " + now + " *** " + "from method: Withdraw() ";
                log objt = new log();
                objt.WriteToLogFile(t);

            }
            catch (Exception ex)
            {
                string text = "Error Log written date: " + now + " *** " + "from method: Withdraw() ";
                log obj = new log();
                obj.WriteToErrFile(text);
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
        }

        public void Transactions(int s)
        {
            DateTime now = DateTime.Now;
            try
            {
                int n = (tr.Count) - 1;
                int v = n - s;
                for (int k = n; k > v; k--)
                {
                    tr[k].trnum(accountNum);
                }
                WriteLine($"Your balance is {Balance:C} now.");
                string t = "Log written date: " + now + " *** " + "from method: Transactions() ";
                log obja = new log();
                obja.WriteToLogFile(t);

            }
            catch (Exception ex)
            {
                string text = "Error Log written date: " + now + " *** " + "from method: Transactions() ";
                log obj = new log();
                obj.WriteToErrFile(text);
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
        }

        public void AllAcc()
        {
            DateTime now = DateTime.Now;
            try
            {
                WriteLine($"Account number: {accountNum}, Name: {Name}");

            }
            catch (Exception ex)
            {
                string text = "Error Log written date: " + now + " *** " + "from method: AllAcc() ";
                log obj = new log();
                obj.WriteToErrFile(text);
                WriteLine($"{ex.GetType()} says {ex.Message}");

            }
        }
    }
}
using static System.Console;
using System.Collections.Generic;
using transactions;


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

            Balance += addAmt;
            DateTime now = DateTime.Now;
            tr.Add(new trans(addAmt, Balance, now));
            WriteLine($"Your balance is {Balance:C} now.");

        }
        public void Withdraw(double outAmt)
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
            DateTime now = DateTime.Now;
            tr.Add(new trans(outAmt * -1, Balance, now));

        }
        public void Transactions(int s)
        {
            int n = (tr.Count) - 1;
            int v = n - s;
            for (int k = n; k > v; k--)
            {
                tr[k].trnum(accountNum);
            }
            WriteLine($"Your balance is {Balance:C} now.");
        }


        public void AllAcc()
        {
            WriteLine($"Account number: {accountNum}, Name: {Name}");
        }
    }

}
using static System.Console;
using System.Collections.Generic;
using BankAccount;
using transactions;

class Bank
{
    static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        List<Account> accountslist = new List<Account>();        

        while (true)
        {
            WriteLine("******Welcome to our bank******");
            WriteLine("Please select your action:");
            WriteLine("a.Open Account  b.Deposite  c.Withdraw  d.Transaction e.All Accounts");

            string? ch = ReadLine();

            switch (ch)
            {
                case "a":

                    CreateAcc();
                    break;

                case "b":

                    DepositToAcc();
                    break;

                case "c":

                    WithdrawFromAcc();
                    break;

                case "d":

                    GetTrans();
                    break;

                case "e":
                    
                    foreach(Account acc in accountslist)
                    {
                        acc.AllAcc();
                    }
                    break;

            }
        }

        void CreateAcc()
        {
            Write("Enter your name:");
            string? name = ReadLine();
            Write("Enter your account number:");
            int acnum = int.Parse(ReadLine());
            Write("Enter your initial balance:");
            double init = double.Parse(ReadLine());
            accountslist.Add(new Account(name, acnum, init));

            for (int i = 0; i < accountslist.Count; i++)
                {
                    if (accountslist[i].accountNum.Equals(acnum))
                        {
                            DateTime now = DateTime.Now;
                            accountslist[i].tr.Add(new trans(acnum, init,now));
                        } 
                }
                    
            WriteLine("Your account added successfully.");
        }
        void DepositToAcc()
        {
            Write("Enter your account number:");
            int nmChk = int.Parse(ReadLine());
            bool f = true;

            for (int i = 0; i < accountslist.Count; i++)
                {
                    if (accountslist[i].accountNum.Equals(nmChk))
                        {
                            Write("Amount to deposite:");
                            double amt = double.Parse(ReadLine());
                            accountslist[i].Deposit(amt);
                            DateTime now = DateTime.Now;
                            accountslist[i].tr.Add(new trans(nmChk, amt,now));
                            f = false;
                        } 
                    }
            if (f == true)
                {
                    WriteLine("your account doesn't exist.");
                }
        }
        void WithdrawFromAcc()
        {
            Write("Enter your account number:");
            int numChk = int.Parse(ReadLine());
            bool fl = true;

            for (int i = 0; i < accountslist.Count; i++)
                {
                    if (accountslist[i].accountNum.Equals(numChk))
                        {                            
                            Write("Amount to withdraw:");
                            double amt = double.Parse(ReadLine());
                            accountslist[i].Withdraw(amt); 
                            DateTime now = DateTime.Now;
                            accountslist[i].tr.Add(new trans(numChk, amt*-1,now));                                               
                            fl = false;
                        }                        
                }
            if (fl == true)
                {
                    WriteLine("your account doesn't exist.");
                }
        }

        void GetTrans()
        {
            Write("Enter your account number:");
            int nChk = int.Parse(ReadLine());
            bool fla = true;
            Write("Enter the number of transactions you want:");
            int tn = int.Parse(ReadLine());

            for (int i = 0; i < accountslist.Count; i++)
                {
                    if (accountslist[i].accountNum.Equals(nChk))
                        {                            
                            int n = (accountslist[i].tr.Count)-1;
                            WriteLine($"size:{n}");
                            int v = n - tn;
                            for (int k = n; k> v; k--)
                            {
                                accountslist[i].tr[k].trnum();
                            }
                            accountslist[i].Transactions(nChk);
                            fla = false;
                        }
                        
                }
            if (fla == true)
                {
                    WriteLine("your account doesn't exist.");
                }
        }
    }
     
}
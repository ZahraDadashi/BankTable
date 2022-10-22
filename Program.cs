using static System.Console;
using System.Collections.Generic;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

using BankAccount;
using transactions;
using logProject;

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
            try
            {
                WriteLine("******Welcome to our bank******");
                WriteLine("Please select your action:");
                WriteLine("a.Open Account  b.Deposite  c.Withdraw  d.Transaction e.All Accounts");

                string? ch = ReadLine();

                switch (ch)
                {
                    case "a":

                        Write("Enter your name:");
                        string? name = ReadLine();
                        Write("Enter your account number:");
                        int acnum = int.Parse(ReadLine());
                        Write("Enter your initial balance:");
                        double init = double.Parse(ReadLine());
                        Account obj = new Account(name, acnum, init);
                        DateTime now = DateTime.Now;
                        obj.tr.Add(new trans(init, init, now));
                        accountslist.Add(obj);
                        WriteLine("Your account added successfully.");
                        string t = "Log written date: " + now + " *** " + "from method: while loop";
                        log ob = new log();
                        ob.WriteToLogFile(t);




                        break;

                    case "b":

                        Write("Enter your account number:");
                        int nmChk = int.Parse(ReadLine());
                        bool f = true;
                        for (int i = 0; i < accountslist.Count; i++)
                        {
                            if (accountslist[i].accountNum.Equals(nmChk))
                            {
                                Write("Amount to deposit:");
                                double amt = double.Parse(ReadLine());
                                accountslist[i].Deposit(amt);
                                f = false;
                            }
                        }
                        if (f == true)
                        {
                            WriteLine("your account doesn't exist.");
                        }

                        break;

                    case "c":

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
                                fl = false;
                            }
                        }
                        if (fl == true)
                        {
                            WriteLine("your account doesn't exist.");
                        }

                        break;

                    case "d":

                        Write("Enter your account number:");
                        int nChk = int.Parse(ReadLine());
                        bool fla = true;

                        for (int i = 0; i < accountslist.Count; i++)
                        {
                            if (accountslist[i].accountNum.Equals(nChk))
                            {
                                Write("Enter the number of transactions you want:");
                                int tn = int.Parse(ReadLine());
                                accountslist[i].Transactions(tn);
                                fla = false;
                            }

                        }
                        if (fla == true)
                        {
                            WriteLine("your account doesn't exist.");
                        }
                        break;

                    case "e":

                        foreach (Account acc in accountslist)
                        {
                            acc.AllAcc();
                        }
                        break;

                }

            }
            catch (Exception ex)
            {
                DateTime n = DateTime.Now;
                string text = "Error Log written date: " + n + " *** " + "from method: while loop";
                log obje = new log();
                obje.WriteToErrFile(text);
                WriteLine($"{ex.GetType()} says {ex.Message}");

            }


        }
    }

}
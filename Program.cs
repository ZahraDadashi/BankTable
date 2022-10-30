using static System.Console;
using System.Collections.Generic;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bd = new BankData())
            {
                while (true)
                {
                    try
                    {
                        WriteLine("******Welcome to our bank******");
                        WriteLine("Please select your action:");
                        WriteLine("a.Create Account  b.Read Account  c.Update Account  d.Delete Account e.Get Transactions");

                        string? ch = ReadLine();

                        switch (ch)
                        {
                            case "a":
                                try
                                {
                                    Write("Enter your name:");
                                    string? name = ReadLine();
                                    Write("Enter your initial balance:");
                                    double init = double.Parse(ReadLine());
                                    var ac = new Account()
                                    {
                                        Name = name,
                                        Balance = init
                                    };
                                    bd.Accounts.Add(ac);
                                    bd.SaveChanges();
                                    int id = ac.AccountID;
                                    DateTime now = DateTime.Now;
                                    var tr = new trans()
                                    {
                                        AccNum = id,
                                        changeAmt = init,
                                        Balance = init,
                                        time = now
                                    };

                                    bd.Transactions.Add(tr);
                                    bd.SaveChanges();
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Create Account";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);

                                }
                                catch (Exception ex)
                                {
                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Create Account";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
                                }
                                break;
                            case "b":
                                try
                                {
                                    WriteLine("{0,-10}{1,-10}{2,-10}",
                                    "AccountID", "Name", "Balance");
                                    foreach (Account a in bd.Accounts.
                                    OrderBy(acc => acc.AccountID))
                                    {
                                        WriteLine("{0,-10}{1,-10}{2,-10}",
                                        a.AccountID, a.Name, a.Balance);
                                    }
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Read Account";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);
                                }
                                catch (Exception ex)
                                {
                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Read Account";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
                                }
                                break;

                            case "c":
                                Write("Please enter you account number:");
                                int acnum = int.Parse(ReadLine());
                                Write("Enter your deposit/withdraw:");
                                double newBal = double.Parse(ReadLine());
                                var v = bd.Accounts.SingleOrDefault(a => a.AccountID == acnum);
                                if (v != null)
                                {
                                    try
                                    {
                                        v.Balance += newBal;
                                        bd.SaveChanges();
                                        DateTime now2 = DateTime.Now;
                                        var b = new trans()
                                        {
                                            AccNum = acnum,
                                            changeAmt = newBal,
                                            Balance = v.Balance,
                                            time = now2
                                        };
                                        bd.Transactions.Add(b);
                                        bd.SaveChanges();
                                        DateTime now1 = DateTime.Now;
                                        string t = "Log written date: " + now1 + " *** " + "from method: Update Account";
                                        log ob = new log();
                                        ob.WriteToLogFile(t);
                                    }
                                    catch (Exception ex)
                                    {
                                        DateTime n = DateTime.Now;
                                        string text = "Error Log written date: " + n + " *** " + "from method: Update Account";
                                        log obje = new log();
                                        obje.WriteToErrFile(text);
                                        WriteLine($"{ex.GetType()} says {ex.Message}");
                                    }
                                }

                                break;
                            case "d":
                                Write("Please enter you account number:");
                                int acnumber = int.Parse(ReadLine());
                                IQueryable<Account>? r = bd.Accounts?.Where(
                                            a => a.AccountID == acnumber);
                                if (r != null)
                                {
                                    try
                                    {
                                        bd.Accounts.RemoveRange(r);
                                        bd.SaveChanges();
                                        DateTime now1 = DateTime.Now;
                                        string t = "Log written date: " + now1 + " *** " + "from method: Delete Account";
                                        log ob = new log();
                                        ob.WriteToLogFile(t);
                                    }
                                    catch (Exception ex)
                                    {
                                        DateTime n = DateTime.Now;
                                        string text = "Error Log written date: " + n + " *** " + "from method: Delete Account";
                                        log obje = new log();
                                        obje.WriteToErrFile(text);
                                        WriteLine($"{ex.GetType()} says {ex.Message}");
                                    }
                                }
                                break;
                            case "e":
                                try
                                {
                                    Write("Please enter you account number:");
                                    int accountnum = int.Parse(ReadLine());
                                    WriteLine("Your transactions are:");
                                    WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}",
                                    "TransactionID", "ChangeAamount", "Balance", "Time");
                                    foreach (trans f in bd.Transactions.Where(a => a.AccNum == accountnum))
                                    {
                                        WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}",
                                    f.TransID, f.changeAmt, f.Balance, f.time);
                                    }
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Get Transactions";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);
                                }
                                catch (Exception ex)
                                {

                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Get Transactions";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
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
    }
}






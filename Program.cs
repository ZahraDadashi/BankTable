using static System.Console;
using System.Collections.Generic;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Packt.Shared;
using ConvertTime;

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
                        WriteLine("f.Max Transaction  g.Max Five Transactions  h.Mean Balance  i.Two Accounts Info.");


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
                                    var now = DateTime.Now;
                                    var tr = new trans()
                                    {
                                        AccNum = id,
                                        changeAmt = init,
                                        Balance = init,
                                        Date = ConvertDateTime.ConvertMiladiToShamsiNoSlash(now),
                                        Year = ConvertDateTime.ConvertMiladiToShamsiYear(now),
                                        Month = ConvertDateTime.ConvertMiladiToShamsiMonth(now),
                                        Day = ConvertDateTime.ConvertMiladiToShamsiDay(now),
                                        Hour = now.Hour,
                                        Minute = now.Minute,
                                        Second = now.Second
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
                                            Date = ConvertDateTime.ConvertMiladiToShamsiNoSlash(now2),
                                            Year = ConvertDateTime.ConvertMiladiToShamsiYear(now2),
                                            Month = ConvertDateTime.ConvertMiladiToShamsiMonth(now2),
                                            Day = ConvertDateTime.ConvertMiladiToShamsiDay(now2),
                                            Hour = now2.Hour,
                                            Minute = now2.Minute,
                                            Second = now2.Second
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
                                    WriteLine("{0,-15}{1,-15}{2,-15}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}{8,-8}",
                                    "TransactionID", "ChangeAamount", "Balance", "Year", "Month", "Day", "Hour", "Minute", "Second");
                                    
                                    var q2 = bd.Transactions
                                    .Where(a => a.AccNum == accountnum);
                                    foreach (trans f in q2)
                                    {
                                        WriteLine("{0,-15}{1,-15}{2,-15}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}{8,-8}",
                                    f.TransID, f.changeAmt, f.Balance, f.Year, f.Month, f.Day, f.Hour, f.Minute, f.Second);
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

                            case "f":
                                try
                                {
                                    Write("Please enter your account number:");
                                    int ac1 = int.Parse(ReadLine());

                                    var query = bd.Transactions
                                    .Where(a => a.AccNum == ac1)
                                    .Max(b => Math.Abs(b.changeAmt));
                                    WriteLine($"Your maximum transaction is:{query}");
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Max Transaction";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);
                                }
                                catch (Exception ex)
                                {
                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Max Transaction";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
                                }

                                break;

                            case "g":

                                try
                                {
                                    Write("Please enter your account number:");
                                    int ac2 = int.Parse(ReadLine());

                                    var q = bd.Transactions
                                    .Where(a => a.AccNum == ac2)
                                    .OrderByDescending(b => Math.Abs(b.changeAmt))
                                    .ToList();
                                    for (int i = 0; i < 5; i++)
                                    {
                                        WriteLine($"Your maximum transaction is:{q[i].changeAmt}");
                                    }
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Max Five Transactions";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);

                                }
                                catch (Exception ex)
                                {
                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Max Five Transactions";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
                                }

                                break;

                            case "h":
                                try
                                {
                                    Write("Please enter your account number:");
                                    int ac3 = int.Parse(ReadLine());
                                    Write("From date:");
                                    DateTime d1 = DateTime.Parse(ReadLine());
                                    Write("To date:");
                                    DateTime d2 = DateTime.Parse(ReadLine());
                                    TimeSpan Result = d2.Subtract(d1);
                                    int dividedTo = (Result.Days) + 1;
                                    double avg = 0;
                                    for (DateTime i = d1; i <= d2; i = i.AddDays(1))
                                    {
                                        string dshamsi = ConvertDateTime.ConvertDateToString(i.AddDays(1));
                                        double last = GetBalance(ac3, dshamsi, bd);
                                        avg += last;
                                    }
                                    WriteLine($"Your average balance from {d1.ToString(@"yyyy/M/d")} to {d2.ToString(@"yyyy/M/d")} is:{avg / dividedTo}");
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Mean Balance";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);
                                }
                                catch (Exception ex)
                                {
                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Mean Balance";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
                                }


                                break;

                            case "i":
                                try
                                {
                                    Write("Please enter your first account number:");
                                    int ac4 = int.Parse(ReadLine());
                                    Write("Please enter your second account number:");
                                    int ac5 = int.Parse(ReadLine());

                                    var q3 = bd.Accounts
                                    .Where(a => a.AccountID == ac4)
                                    .ToList();
                                    var q4 = bd.Accounts
                                    .Where(a => a.AccountID == ac5)
                                    .ToList();
                                    WriteLine("{0,-15}{1,-15}{2,-15}",
                                        "AccountID", "Name", "Balance");
                                    WriteLine($"{q3[0].AccountID,-15}{q3[0].Name,-15}{q3[0].Balance,-15}");
                                    WriteLine($"{q4[0].AccountID,-15}{q4[0].Name,-15}{q4[0].Balance,-15}");
                                    DateTime now1 = DateTime.Now;
                                    string t = "Log written date: " + now1 + " *** " + "from method: Two Accounts Info";
                                    log ob = new log();
                                    ob.WriteToLogFile(t);
                                }
                                catch (Exception ex)
                                {
                                    DateTime n = DateTime.Now;
                                    string text = "Error Log written date: " + n + " *** " + "from method: Two Accounts Info";
                                    log obje = new log();
                                    obje.WriteToErrFile(text);
                                    WriteLine($"{ex.GetType()} says {ex.Message}");
                                }

                                break;
                        }//switch

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

        private static double GetBalance(int ac, string d, BankData? bd)
        {

            var q6 = bd.Transactions
             .Where(a => a.AccNum == ac)
             .Where(b => Convert.ToInt32(b.Date) < Convert.ToInt32(d))
             .OrderBy(c => c.TransID)
             .ToList()
             .LastOrDefault();
            if (q6 != null)
            {
                double lastBal = q6.Balance;
                return lastBal;
            }
            else
            {
                return 0;
            }
        }
    }
}






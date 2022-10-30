using Microsoft.EntityFrameworkCore;
using static System.Console;
namespace Packt.Shared;
public class BankData : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<trans> Transactions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog = BankData; Integrated Security = true; MultipleActiveResultSets = true; ");
        /*builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });
        base.OnConfiguring(optionsBuilder);*/
        //builder => builder.EnableRetryOnFailure()
    }
}



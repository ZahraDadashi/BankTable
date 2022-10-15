using BankAccount;
namespace transactions
{
    public class trans
    {
        public double changeAmt;
        public double Balance;
        public DateTimeOffset time;
        public trans( double amt,double Bal,DateTimeOffset n)
        {
            changeAmt = amt;
            time = n;
            Balance = Bal;
            
        }
        public void trnum(int accNum)
        {  
            Console.WriteLine($"Account number:{accNum,-5} deposit/withdraw:{changeAmt,-5} Balance:{Balance,-5} at:{time,-5}");
        }
        
    }
}
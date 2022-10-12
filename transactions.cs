using BankAccount;
namespace transactions
{
    public class trans
    {
        public int accountNum;
        public double changeAmt;
        public DateTimeOffset time;
        public trans(int accNum, double amt,DateTimeOffset n)
        {
            accountNum = accNum;
            changeAmt = amt;
            time = n;
        }
        public void trnum()
        {  
            Console.WriteLine($"Account number:{accountNum} deposit/withdraw:{changeAmt} at:{time}");
        }
        
    }
}
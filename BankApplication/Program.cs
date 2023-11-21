namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Ali", 100000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(120, DateTime.Now, "Hammok");
            account.MakeWithdrawal(120, DateTime.Now, "Xbox Game");

            Console.WriteLine(account.GetAccountHistory());


            // Test for a negative balance:
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -50);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}

            //account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");
            //Console.WriteLine(account.Balance);
        }
    }
}

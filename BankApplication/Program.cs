namespace BankApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Ali", 1000000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

        }
    }
}

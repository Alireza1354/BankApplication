using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    internal class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in transactions)
                {
                    //balance = balance + item.Amount;
                    balance += item.Amount;
                }
                return balance;
            }
        }

        // It's private, which means it can only be accessed by code inside the BankAccount class.
        // It's static, which means it's shared by all of the BankAccount objects.
        // Every bank account has the same seed.
        private static int accountNumberSeed = 1234567890;

        // One bank account has many different transactions associated with it.
        private List<Transaction> transactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
            }
            var deposit = new Transaction(amount, date, note);
            transactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal.");
            }
            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);
        }
    }
}

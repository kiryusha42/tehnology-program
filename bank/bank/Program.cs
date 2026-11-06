using BankAccounts.Core.AccountNumbers;
using BankAccounts.Core.Factories;
using BankAccounts.Core.Statements;
using BankAccounts.Core.Time;
namespace BankAccounts.Core.Accounts;

namespace BankAccounts.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clock = new SystemClock();
            var factory =
                new AccountFactory(clock, new SequentialAccountNumberGenerator());
            var formatter = new TextStatementFormatter();

            var savings = factory.CreateInterestEarning("Yana", 10000m);
            savings.Deposit(100m, clock.Now, "asda");

            System.Console.WriteLine(formatter.Format(savings.Transactions));


            var deposit = factory.CreateDebitAccount("Yana", 1000m);
            deposit.Withdrawal(500m, clock.Now, "asda");


            var credit = factory.CreateLineOfCredit("asd", 500m);
            credit.Withdrawal(300m, clock.Now, "sdf");

            List<BankAccount> accounts = new List<BankAccount>()
            {
                savings,
                deposit,
                credit
            };

            foreach (var account in accounts)
            {
                System.Console.WriteLine(formatter.Format(account.Transaction));
                System.Console.WriteLine();
                account.PerforMonthEndTransactions();
            }


            
        }
    }
}
using System.Text;

namespace bank;


// BankAccoun - потомок класса object => можно переопределить 

public class BankAccount
{
    private List<Transaction> _allTransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }
    public string Number { get; }
    private static int s_accountNumberSeed = 1000000000;
    public BankAccount(string name, decimal initialBalance)
    {
        Owner = name;
        MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }
    public void MakeDeposite(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount off deposite must be positive");
        }
        var deposite = new Transaction(amount, date, note);
        _allTransactions.Add(deposite);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount off withdrawal must be positive");
        }

        if (Balance < amount)
        {
            throw new InvalidOperationException("Not sufficient rubls for this withdrawal");
        }

        var withdrawal = new Transaction(-amount, date, note);
        _allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }



// ключевое слово virtual позволяет в дочерном классе представить другую реализацию метода PerformMonthAndTransactions()

public virtual void PerformMonthAndTransactions()

{

    }
    // переопрелеояем метод который унаследовали от object 
    // этот метод должен возвращать строку с состоянием объекта 
    //public override string ToString()
    //{
    //    return $"Type: Owner: {Owner}\tNumber of account: {Number}";
    //}
    public override string ToString()
        => $"Type: {GetType().Name}\tOwner: {Owner}\tNumber of account: {Number}";
}




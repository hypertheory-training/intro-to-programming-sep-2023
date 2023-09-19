namespace Banking.Domain;
public record TransactionValueTypes
{
    public record Deposit : TransactionValueTypes { }
    public record Withdrawl : TransactionValueTypes { }
    public record Balance : TransactionValueTypes { }
}


// Deposit(decimal amount)
// Withdraw(decimal amount)
// GetBalance => decimal
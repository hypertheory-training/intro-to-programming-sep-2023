namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M;
    public void Deposit(TransactionValueTypes.Deposit amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public TransactionValueTypes.Balance GetBalance()
    {

        return _balance;
    }
    // "Primitive Obsession" -
    public void Withdraw(TransactionValueTypes.Withdrawl amountToWithdraw)
    {
        GuardHasSufficientFunds(amountToWithdraw);

        _balance -= amountToWithdraw; // The important business!
    }

    private void GuardHasSufficientFunds(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {
            throw new OverdraftException();
        }
    }
}

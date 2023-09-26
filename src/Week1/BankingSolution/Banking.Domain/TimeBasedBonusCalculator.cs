namespace Banking.Domain;

public class TimeBasedBonusCalculator : ICalculateBonusesForDeposits
{
    private readonly IProvideTheBusinessClock _businessClock;

    public TimeBasedBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public decimal CalculateBonusFor(Account account, TransactionValueTypes.Deposit amountToDeposit)
    {
        return CalculateBonusForAccountDeposit(account.GetBalance(), amountToDeposit.Value);
    }

    public decimal CalculateBonusForAccountDeposit(decimal balance, decimal deposit)
    {

        bool open = this._businessClock.IsOpen();
        if (open)
        {
            return balance >= 5000M ? deposit * .13M : 0;
        }
        else
        {
            return balance >= 5000M ? deposit * .10M : 0;
        }
    }
}
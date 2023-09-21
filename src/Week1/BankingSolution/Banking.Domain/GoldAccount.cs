namespace Banking.Domain;

public class GoldAccount : Account
{
    public override void Deposit(TransactionValueTypes.Deposit amountToDeposit)
    {
        var updatedDeposit = TransactionValueTypes.Deposit.CreateFrom(amountToDeposit.Value * 1.10M);
        base.Deposit(updatedDeposit);
    }
}
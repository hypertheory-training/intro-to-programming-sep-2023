using Banking.Domain;

namespace Banking.UnitTests.BankAccount;
public class GoldAccountsGetABonus
{
    [Fact]
    public void GoldAccountsGetABonusOnDeposits()
    {
        Account account = new GoldAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        var deposit = TransactionValueTypes.Deposit.CreateFrom(100M);

        account.Deposit(deposit);

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());

    }
}


using Banking.Domain;

namespace Banking.UnitTests.BankAccount;
public class MakingDeposits
{
    [Fact]
    public void MakingADepositIncreasesTheBalance()
    {
        // Given
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 125.23M;

        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
    [Fact]
    public void CannotDepositInvalidValues()
    {
        var account = new Account();

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            account.Deposit(-1);

        });


    }
}

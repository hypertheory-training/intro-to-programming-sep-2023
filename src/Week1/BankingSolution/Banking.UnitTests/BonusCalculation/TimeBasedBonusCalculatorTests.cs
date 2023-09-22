using Banking.Domain;
using NSubstitute;

namespace Banking.UnitTests.BonusCalculation;
public class TimeBasedBonusCalculatorTests
{

    [Theory]
    [InlineData(5000, 100, 10)]

    public void MakingDepositsOutsideOfBusinessHoursWithAdequateBalance(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var fakeBusinessClock = Substitute.For<IProvideTheBusinessClock>();
        fakeBusinessClock.IsOpen().Returns(false);
        var calculator = new TimeBasedBonusCalculator(fakeBusinessClock);

        decimal bonus = calculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }

    [Theory]
    [InlineData(5000, 100, 13)]

    public void MakingDepositsDuringBusinessHoursGetBonus(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var fakeBusinessClock = Substitute.For<IProvideTheBusinessClock>();
        fakeBusinessClock.IsOpen().Returns(true);
        var calculator = new TimeBasedBonusCalculator(fakeBusinessClock);

        decimal bonus = calculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }


    [Theory]
    [InlineData(4999.99, 100, 0)]
    [InlineData(4999.99, 200, 0)]
    public void MakingDepositsThatDontHaveAdequateBalanceGetNoBonus(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var fakeBusinessClock = Substitute.For<IProvideTheBusinessClock>();
        fakeBusinessClock.IsOpen().Returns(false);
        var calculator = new TimeBasedBonusCalculator(fakeBusinessClock);

        decimal bonus = calculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }


}


/*
 *     Given you have an account with a balance of 5000 or more
    And you make your deposit outside of business hours
    When you make a deposit
    Then you get 10% added to your deposit (as before)

    Given you have an account with a balance of 5000 or more
    And you make your deposit during business hours
    When you make a deposit
    Then

    balance => deposit => bonus

    8000+        -> 100 => 13 (13%)
*/
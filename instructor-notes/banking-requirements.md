# Banking Application


## BankAccount

X Has a Balance
    - New Accounts have a 5000 balance.
X The holder can deposit money into the account - this should increase the balance
X The holder can withdraw money from the account - this should decrease the balance



## Gold Accounts


"Some accounts are gold accounts. They get a bonus on all deposits."

- The business hasn't told us yet what the requirements for being a gold account are.
- The business hasn't told us yet what the bonus should be.


## Bonus Calculation

- Right now, if you have >= 5000, you get 10% added to your deposit.

- Future - 
    Given you have an account with a balance of 5000 or more
    And you make your deposit outside of business hours
    When you make a deposit
    Then you get 10% added to your deposit (as before)

    Given you have an account with a balance of 5000 or more
    And you make your deposit during business hours
    When you make a deposit
    Then

    balance => deposit => bonus
    5000-5999.99 -> 100 => 10 (10%)
    6000-6999.99 -> 100 => 11 (11%)
    7000-7999.99 -> 100 => 12 (12%)
    8000+        -> 100 => 13 (13%)

## Business Hours
    - We are going to need an API for this so everyone can know if we are open or closed.
    9:00 AM - 5:00 PM Monday-Friday (Eastern Time Zone)
    Closed on Weekends
    Closed on the following holidays:
        - Christmas (Dec 25)
        - New Years (Jan 1)
        - Fourth of July (Jul 4)
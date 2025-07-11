
static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        //This confused me a bit at first because they want us to write out the percentage like this
        //but to do the actual calculation we need to divide by 100, why not just allow
        //us to write it out as .03213 for example here? :/
        //
        //I do understand that a lot of times, solving these problems is more about 
        //understanding the problem at hand, and what is desired, so I get it in that sense.
        if (balance < 0) {
            return 3.213f;
        } 
        if (balance >= 0 && balance < 1000) {
            return .5f;
        } 
        if (balance >= 1000 && balance < 5000) {
            return 1.621f;
        } 
        return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        //I've done the conversioning :)
        return balance*(decimal)InterestRate(balance)/100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance+Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        decimal newBalance = AnnualBalanceUpdate(balance);
        //Its already the first year because I already did one AnnualBalanceUpdate
        int years = 1;
        while (newBalance <= targetBalance) {
            newBalance = AnnualBalanceUpdate(newBalance);
            years++;
        } 
        return years; 
    }
}

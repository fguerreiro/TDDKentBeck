using System;

namespace TddKentBeckTests
{
    public interface IMoneyExpression
    {
        IMoneyExpression Plus(Money addend);
        Money Reduce(Bank bank, String to);
    }
}
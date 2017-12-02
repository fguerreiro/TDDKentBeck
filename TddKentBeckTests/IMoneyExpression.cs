using System;

namespace TddKentBeckTests
{
    public interface IMoneyExpression
    {
        IMoneyExpression Plus(IMoneyExpression addend);
        IMoneyExpression Times(int multiplier);
        Money Reduce(Bank bank, String to);
    }
}
using System;

namespace TddKentBeckTests
{
    public interface IMoneyExpression
    {
        IMoneyExpression Plus(IMoneyExpression addend);
        Money Reduce(Bank bank, String to);
    }
}
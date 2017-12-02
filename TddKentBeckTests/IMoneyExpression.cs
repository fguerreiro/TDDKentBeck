using System;

namespace TddKentBeckTests
{
    public interface IMoneyExpression
    {
        IMoneyExpression Plus(Money addend);
        Money Reduce(String to);
    }
}
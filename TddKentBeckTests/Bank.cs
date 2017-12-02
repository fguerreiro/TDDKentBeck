using System;

namespace TddKentBeckTests
{
    public class Bank 
    {
        public Money Reduce(IMoneyExpression source, String to)
        {
            return source.Reduce(to);
        }
    }
}
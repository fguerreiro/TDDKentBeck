using System;

namespace TddKentBeckTests
{
    public class Sum : IMoneyExpression
    {
        public Money Augend { get; set; }
        public Money Addend { get; set; }

        public Sum(Money augend, Money addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public IMoneyExpression Plus(Money addend)
        {
            throw new NotImplementedException();
        }
        
    }
}
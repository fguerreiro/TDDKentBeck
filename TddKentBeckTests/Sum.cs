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

        public Money Reduce(Bank bank, String to)
        {
            int amount = Augend.Amount + Addend.Amount;
            return new Money(amount, to);
        }
        
        public IMoneyExpression Plus(Money addend)
        {
            throw new NotImplementedException();
        }
        
    }
}